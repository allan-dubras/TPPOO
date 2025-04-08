using System.Collections;
using UnityEngine;

namespace TP2_Heritage
{
    public class Skeleton : Ennemie
    {
        [SerializeField]
        private bool SecondLife;

        public Skeleton(int health, int damage, float speed, float detectionRange, Transform player, bool secondLife)
        {
            Health = health;
            Damage = damage;
            Speed = speed;
            DetectionRange = detectionRange;
            Player = player;
            SecondLife = secondLife;
        }
        public void relife()
        {
           gameObject.SetActive(true);
            health = 80;
        }
        public override void Die()
        {
            base.Die();
            if (SecondLife)
            { 
                StartCoroutine(life());
            }
        }
        IEnumerator life()
        {
            yield return new WaitForSeconds(3f);
            relife();
        }
        public void Update()
        {
            base.Update();
        }
    }
}