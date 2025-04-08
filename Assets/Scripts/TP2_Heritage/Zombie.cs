using UnityEngine;

namespace TP2_Heritage
{
    public class Zombie : Ennemie
    {
        [SerializeField]
        private int RegenHp;


        public Zombie(int health, int damage, float speed, float detectionRange, Transform player, int regenHp)
        {
            RegenHp = regenHp;
            Health = health;
            Damage = damage;
            Speed = speed;
            DetectionRange = detectionRange;
            Player = player;
            RegenHp = regenHp;
        }

        public void Regen()
        {
            health += RegenHp;
            if (health > 100) 
            {
                health = 100;
            }
        }
        public void Update()
        {
            base.Update();
            if (!inFight)
            {
                Regen();
            }
        }
    }
}