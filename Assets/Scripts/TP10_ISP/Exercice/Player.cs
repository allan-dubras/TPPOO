using System;
using System.Collections.Generic;
using UnityEngine;

namespace TP10
{
    // Personnage jouable
    public class Player : IGameCharacter
    {
        public string Name { get; private set; }
        public int Health { get; set; }
        public Vector3 Position { get; set; }
        public bool IsAlive => Health > 0;

        // Inventaire et autres propriétés spécifiques au joueur
        private List<IItem> inventory = new List<IItem>();

        public Player(string name, int health, Vector3 position)
        {
            Name = name;
            Health = health;
            Position = position;
        }

        // Implémentations des méthodes de l'interface

        // Méthodes de mouvement - Utilisées par le joueur
        public void Move(Vector3 direction) { /* Implémentation */ }
        public void Jump() { /* Implémentation */ }
        public void Crouch() { /* Implémentation */ }
        public void Swim() { /* Implémentation */ }
        public void Climb() { /* Implémentation */ }
        public void Fly() { /* Implémentation */ }

        // Méthodes de combat - Utilisées par le joueur
        public void Attack(IGameCharacter target) { /* Implémentation */ }
        public void Defend() { /* Implémentation */ }
        public void UseSpecialAbility() { /* Implémentation */ }
        public void CastSpell(string spellName, IGameCharacter target) { /* Implémentation */ }
        public void Heal(IGameCharacter target, int amount) { /* Implémentation */ }

        // Méthodes d'interaction - Utilisées par le joueur
        public void PickupItem(IItem item) { inventory.Add(item); }
        public void UseItem(IItem item) { item.Use(this); }
        public void Speak(string dialogue) { Debug.Log($"{Name} says: {dialogue}"); }
        public void Trade(IGameCharacter trader) { /* Implémentation */ }

        // Méthodes pour les PNJ - Non utilisées par le joueur, implémentations vides ou levant des exceptions
        public void SetPatrolPath(List<Vector3> path) { throw new NotImplementedException("Players don't patrol"); }
        public void FollowPlayer(IGameCharacter player) { throw new NotImplementedException("Players don't follow other players automatically"); }
        public void RespondToInteraction(IGameCharacter interactor) { throw new NotImplementedException("Players respond manually, not automatically"); }
    }
}