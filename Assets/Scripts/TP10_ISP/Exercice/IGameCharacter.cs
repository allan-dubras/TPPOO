using System.Collections.Generic;
using UnityEngine;


namespace TP10
{
    // Interface monolithique problématique
    public interface IGameCharacter
    {
        // Propriétés communes
        string Name { get; }
        int Health { get; set; }
        Vector3 Position { get; set; }
        bool IsAlive { get; }

        // Méthodes de mouvement
        void Move(Vector3 direction);
        void Jump();
        void Crouch();
        void Swim();
        void Climb();
        void Fly();

        // Méthodes de combat
        void Attack(IGameCharacter target);
        void Defend();
        void UseSpecialAbility();
        void CastSpell(string spellName, IGameCharacter target);
        void Heal(IGameCharacter target, int amount);

        // Méthodes d'interaction
        void PickupItem(IItem item);
        void UseItem(IItem item);
        void Speak(string dialogue);
        void Trade(IGameCharacter trader);

        // Méthodes pour les personnages non-joueurs (PNJ)
        void SetPatrolPath(List<Vector3> path);
        void FollowPlayer(IGameCharacter player);
        void RespondToInteraction(IGameCharacter interactor);
    }
}