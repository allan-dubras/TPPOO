
namespace TP7
{
    public class DamageCalculator
    {
        public enum DamageType
        {
            Physical,
            Fire,
            Ice,
            Lightning,
            Poison
        }

        public enum EnemyType
        {
            Ground,
            Flying,
            Aquatic
        }

        // Calcule les dégâts en fonction du type de dégâts et du type d'ennemi
        public float CalculateDamage(float baseDamage, DamageType damageType, Enemy enemy)
        {
            float finalDamage = baseDamage;

            // Ajuster les dégâts en fonction du type d'ennemi
            if (enemy.Type == EnemyType.Ground)
            {
                // Les ennemis terrestres ont des modificateurs spécifiques
                switch (damageType)
                {
                    case DamageType.Physical:
                        finalDamage *= 1.0f;  // Dégâts physiques normaux
                        break;
                    case DamageType.Fire:
                        finalDamage *= 1.2f;  // Vulnérables au feu
                        break;
                    case DamageType.Ice:
                        finalDamage *= 0.8f;  // Résistants au froid
                        break;
                    case DamageType.Lightning:
                        finalDamage *= 1.1f;  // Légèrement vulnérables à l'électricité
                        break;
                    case DamageType.Poison:
                        finalDamage *= 1.3f;  // Très vulnérables au poison
                        break;
                }
            }
            else if (enemy.Type == EnemyType.Flying)
            {
                // Les ennemis volants ont des modificateurs spécifiques
                switch (damageType)
                {
                    case DamageType.Physical:
                        finalDamage *= 0.8f;  // Résistants aux dégâts physiques
                        break;
                    case DamageType.Fire:
                        finalDamage *= 1.0f;  // Dégâts de feu normaux
                        break;
                    case DamageType.Ice:
                        finalDamage *= 1.5f;  // Très vulnérables au froid
                        break;
                    case DamageType.Lightning:
                        finalDamage *= 2.0f;  // Extrêmement vulnérables à l'électricité
                        break;
                    case DamageType.Poison:
                        finalDamage *= 0.7f;  // Résistants au poison
                        break;
                }
            }
            else if (enemy.Type == EnemyType.Aquatic)
            {
                // Les ennemis aquatiques ont des modificateurs spécifiques
                switch (damageType)
                {
                    case DamageType.Physical:
                        finalDamage *= 1.0f;  // Dégâts physiques normaux
                        break;
                    case DamageType.Fire:
                        finalDamage *= 0.5f;  // Très résistants au feu
                        break;
                    case DamageType.Ice:
                        finalDamage *= 1.0f;  // Dégâts de froid normaux
                        break;
                    case DamageType.Lightning:
                        finalDamage *= 1.8f;  // Très vulnérables à l'électricité
                        break;
                    case DamageType.Poison:
                        finalDamage *= 1.2f;  // Légèrement vulnérables au poison
                        break;
                }
            }

            // Appliquer d'autres modificateurs spécifiques à l'ennemi
            finalDamage *= enemy.DamageResistance;

            return finalDamage;
        }
    }
}