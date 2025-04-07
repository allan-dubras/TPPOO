using UnityEngine;

namespace TP2_Heritage
{
    // Cette classe abstraite doit être héritée par tous les types d'ennemis
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected int health;
        [SerializeField] protected int damage;
        [SerializeField] protected float speed;
        [SerializeField] protected float detectionRange;
        
        protected Transform playerTransform;
        
        // Propriétés avec validation
        public int Health 
        {
            get { return health; }
            protected set { health = Mathf.Max(0, value); }
        }
        
        public bool IsAlive => Health > 0;
        
        protected virtual void Start()
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
        protected virtual void Update()
        {
            if (IsAlive && IsPlayerInRange())
            {
                MoveTowardsPlayer();
            }
        }
        
        // Méthodes qui peuvent être surchargées
        public virtual void TakeDamage(int amount)
        {
            if (amount <= 0) return;
            
            Health -= amount;
            
            if (!IsAlive)
            {
                Die();
            }
        }
        
        protected virtual bool IsPlayerInRange()
        {
            if (playerTransform == null) return false;
            
            return Vector3.Distance(transform.position, playerTransform.position) < detectionRange;
        }
        
        protected virtual void MoveTowardsPlayer()
        {
            if (playerTransform == null) return;
            
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        
        protected virtual void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerCharacter player = collision.gameObject.GetComponent<PlayerCharacter>();
                if (player != null)
                {
                    AttackPlayer(player);
                }
            }
        }
        
        // Méthodes abstraites que les classes dérivées doivent implémenter
        protected abstract void AttackPlayer(PlayerCharacter player);
        
        protected abstract void Die();
    }
}