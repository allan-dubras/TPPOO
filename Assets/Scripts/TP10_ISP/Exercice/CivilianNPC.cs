using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TP10
{
    // Personnage non-joueur civil
    public class CivilianNPC : IGameCharacter
    {
        public string Name { get; private set; }
        public int Health { get; set; }
        public Vector3 Position { get; set; }
        public bool IsAlive => Health > 0;

        private List<Vector3> patrolPath;
        private Dictionary<string, string> dialogues = new Dictionary<string, string>();

        public CivilianNPC(string name, int health, Vector3 position)
        {
            Name = name;
            Health = health;
            Position = position;
        }

        // Méthodes de mouvement - Partiellement utilisées
        public void Move(Vector3 direction) { /* Implémentation simple */ }
        public void Jump() { /* Les civils ne sautent généralement pas */ throw new NotImplementedException(); }
        public void Crouch() { /* Les civils ne s'accroupissent généralement pas */ throw new NotImplementedException(); }
        public void Swim() { /* Les civils ne nagent généralement pas */ throw new NotImplementedException(); }
        public void Climb() { /* Les civils ne grimpent généralement pas */ throw new NotImplementedException(); }
        public void Fly() { /* Les civils ne volent certainement pas */ throw new NotImplementedException(); }

        // Méthodes de combat - Non utilisées par les civils
        public void Attack(IGameCharacter target) { throw new NotImplementedException("Civilians don't attack"); }
        public void Defend() { /* Implémentation minimale - fuir */ }
        public void UseSpecialAbility() { throw new NotImplementedException("Civilians don't have special abilities"); }
        public void CastSpell(string spellName, IGameCharacter target) { throw new NotImplementedException("Civilians don't cast spells"); }
        public void Heal(IGameCharacter target, int amount) { throw new NotImplementedException("Civilians don't heal others"); }

        // Méthodes d'interaction - Partiellement utilisées
        public void PickupItem(IItem item) { /* Implémentation minimale ou non implémentée */ }
        public void UseItem(IItem item) { /* Implémentation minimale */ }
        public void Speak(string dialogue) { Debug.Log($"{Name} says: {dialogue}"); }
        public void Trade(IGameCharacter trader) { /* Implémentation pour les civils marchands */ }

        // Méthodes pour les PNJ - Utilisées
        public void SetPatrolPath(List<Vector3> path) { this.patrolPath = path; }
        public void FollowPlayer(IGameCharacter player) { /* Implémentation */ }
        public void RespondToInteraction(IGameCharacter interactor)
        {
            // Répondre avec un dialogue aléatoire
            if (dialogues.Count > 0)
            {
                var randomDialogue = dialogues.ElementAt(new System.Random().Next(dialogues.Count));
                Speak(randomDialogue.Value);
            }
        }

        // Méthodes spécifiques aux civils
        public void AddDialogue(string key, string text)
        {
            dialogues[key] = text;
        }
    }
}