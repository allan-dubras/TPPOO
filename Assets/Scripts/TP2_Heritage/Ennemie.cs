using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ennemie : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float detectionRange;
    [SerializeField]
    protected Transform player;
    [SerializeField]
    protected bool inFight=false;
    [SerializeField]
    protected Rigidbody rb;

    protected int Health { get => health; set => health = value; }
    protected int Damage { get => damage; set => damage = value; }
    protected float Speed { get => speed; set => speed = value; }
    protected float DetectionRange { get => detectionRange; set => detectionRange = value; }
    protected Transform Player { get => player; set => player = value; }

    public Ennemie() { }
    public Ennemie(int health, int damage, float speed, float detectionRange, Transform player)
    {
        Health = health;
        Damage = damage;
        Speed = speed;
        DetectionRange = detectionRange;
        Player = player;
    }
    protected void Start()
    {
        Find();
    }
    protected void Update()
    {
        Move();
        if (rb.velocity.x == 0  )
        {
            inFight = false;
        }
    }

    public void Move()
    {
        if (Vector3.Distance(transform.position, player.position) < detectionRange)
        {
            inFight = true;
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
    public void Find()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public virtual void Die()
    {
        gameObject.SetActive(false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerCharacter player = collision.gameObject.GetComponent<PlayerCharacter>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
}

