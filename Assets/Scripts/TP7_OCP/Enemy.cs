


namespace TP7
{
    public class Enemy
    {
        public DamageCalculator.EnemyType Type { get; protected set; }
        public float Health { get; protected set; }
        public float DamageResistance { get; protected set; } = 1.0f;

        public Enemy(float health, DamageCalculator.EnemyType type, float damageResistance = 1.0f)
        {
            Health = health;
            Type = type;
            DamageResistance = damageResistance;
        }

        public virtual void TakeDamage(float amount, DamageCalculator.DamageType damageType)
        {
            // Utiliser le calculateur pour ajuster les dégâts
            DamageCalculator calculator = new DamageCalculator();
            float finalDamage = calculator.CalculateDamage(amount, damageType, this);

            Health -= finalDamage;

            if (Health <= 0)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
            // Logique de mort de l'ennemi...
        }
    }
}