using System;
using System.Collections.Generic;
using UnityEngine;

namespace TP10
{
    // Objet statique interactif dans le jeu (comme un coffre)
    public class StaticObject : IGameCharacter
    {
        public string Name { get; private set; }
        public int Health { get; set; } // Représente la durabilité de l'objet
        public Vector3 Position { get; set; }
        public bool IsAlive => Health > 0; // Représente si l'objet est intact

        private IItem containedItem;

        public StaticObject(string name, int durability, Vector3 position, IItem containedItem = null)
        {
            Name = name;
            Health = durability;
            Position = position;
            this.containedItem = containedItem;
        }

        // Méthodes de mouvement - Non utilisées par les objets statiques
        public void Move(Vector3 direction) { throw new NotImplementedException("Static objects cannot move"); }
        public void Jump() { throw new NotImplementedException("Static objects cannot jump"); }
        public void Crouch() { throw new NotImplementedException("Static objects cannot crouch"); }
        public void Swim() { throw new NotImplementedException("Static objects cannot swim"); }
        public void Climb() { throw new NotImplementedException("Static objects cannot climb"); }
        public void Fly() { throw new NotImplementedException("Static objects cannot fly"); }

        // Méthodes de combat - Non utilisées par les objets statiques
        public void Attack(IGameCharacter target) { throw new NotImplementedException("Static objects cannot attack"); }
        public void Defend() { throw new NotImplementedException("Static objects cannot defend"); }
        public void UseSpecialAbility() { throw new NotImplementedException("Static objects don't have special abilities"); }
        public void CastSpell(string spellName, IGameCharacter target) { throw new NotImplementedException("Static objects cannot cast spells"); }
        public void Heal(IGameCharacter target, int amount) { throw new NotImplementedException("Static objects cannot heal"); }

        // Méthodes d'interaction - Partiellement utilisées
        public void PickupItem(IItem item) { throw new NotImplementedException("Static objects cannot pick up items"); }
        public void UseItem(IItem item) { throw new NotImplementedException("Static objects cannot use items"); }
        public void Speak(string dialogue) { throw new NotImplementedException("Static objects cannot speak"); }
        public void Trade(IGameCharacter trader) { throw new NotImplementedException("Static objects cannot trade"); }

        // Méthodes pour les PNJ - Non utilisées par les objets statiques
        public void SetPatrolPath(List<Vector3> path) { throw new NotImplementedException("Static objects don't patrol"); }
        public void FollowPlayer(IGameCharacter player) { throw new NotImplementedException("Static objects cannot follow players"); }

        // La seule méthode réellement utile pour un objet statique
        public void RespondToInteraction(IGameCharacter interactor)
        {
            if (containedItem != null && interactor is Player player)
            {
                Debug.Log($"{Name} contains {containedItem.Name}");
                player.PickupItem(containedItem);
                containedItem = null;
            }
            else
            {
                Debug.Log($"{Name} is empty or cannot be interacted with");
            }
        }
    }
}