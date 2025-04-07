using System;
using System.Collections.Generic;
using UnityEngine;

namespace TP10
{
    // Personnage ennemi (PNJ)
    public class Enemy : IGameCharacter
    {
        public string Name { get; private set; }
        public int Health { get; set; }
        public Vector3 Position { get; set; }
        public bool IsAlive => Health > 0;

        private List<Vector3> patrolPath;

        public Enemy(string name, int health, Vector3 position)
        {
            Name = name;
            Health = health;
            Position = position;
        }

        // Méthodes de mouvement - Partiellement utilisées
        public void Move(Vector3 direction) { /* Implémentation */ }
        public void Jump() { /* Implémentation minimale */ }
        public void Crouch() { /* Implémentation minimale ou vide */ }
        public void Swim() { /* Peut-être non implémenté pour certains ennemis */ throw new NotImplementedException(); }
        public void Climb() { /* Peut-être non implémenté pour certains ennemis */ throw new NotImplementedException(); }
        public void Fly() { /* Seulement pour les ennemis volants */ throw new NotImplementedException("This enemy cannot fly"); }

        // Méthodes de combat - Utilisées
        public void Attack(IGameCharacter target) { /* Implémentation */ }
        public void Defend() { /* Implémentation */ }
        public void UseSpecialAbility() { /* Implémentation */ }
        public void CastSpell(string spellName, IGameCharacter target) { /* Pourrait ne pas être implémenté pour les ennemis non-magiques */ }
        public void Heal(IGameCharacter target, int amount) { /* Implémentation */ }

        // Méthodes d'interaction - Partiellement utilisées
        public void PickupItem(IItem item) { /* Généralement non implémenté pour les ennemis */ throw new NotImplementedException(); }
        public void UseItem(IItem item) { /* Généralement non implémenté pour les ennemis */ throw new NotImplementedException(); }
        public void Speak(string dialogue) { Debug.Log($"{Name} growls: {dialogue}"); }
        public void Trade(IGameCharacter trader) { throw new NotImplementedException("Enemies don't trade"); }

        // Méthodes pour les PNJ - Utilisées
        public void SetPatrolPath(List<Vector3> path) { this.patrolPath = path; }
        public void FollowPlayer(IGameCharacter player) { /* Implémentation */ }
        public void RespondToInteraction(IGameCharacter interactor) { /* Implémentation */ }
    }
}