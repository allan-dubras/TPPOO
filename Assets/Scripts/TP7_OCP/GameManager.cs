


namespace TP7
{
    public class GameManager
    {
        public void AttackEnemy(Enemy enemy, float attackPower, DamageCalculator.DamageType damageType)
        {
            enemy.TakeDamage(attackPower, damageType);
        }
    }
}