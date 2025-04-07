using UnityEngine;
using System.Collections.Generic;

namespace TP9
{
    // GameController.cs - Module de haut niveau
    public class GameController : MonoBehaviour
    {
        private NotificationService notificationService;
        
        [SerializeField] private List<Player> players = new List<Player>();
        
        private void Awake()
        {
            notificationService = GetComponent<NotificationService>();
            if (notificationService == null)
            {
                notificationService = gameObject.AddComponent<NotificationService>();
            }
        }

        public void UnlockAchievement(Player player, string achievementName)
        {
            if (player == null) return;
            
            Debug.Log($"Achievement '{achievementName}' unlocked for {player.Name}");
            notificationService.NotifyPlayerAchievementUnlocked(player, achievementName);
        }

        public void InvitePlayerToGame(Player inviter, Player invitee, string gameName)
        {
            if (inviter == null || invitee == null) return;
            
            Debug.Log($"{inviter.Name} invited {invitee.Name} to play {gameName}");
            notificationService.NotifyPlayerGameInvite(inviter, invitee, gameName);
        }

        // Example method to demonstrate usage in Unity
        public void TestNotifications()
        {
            if (players.Count >= 2)
            {
                UnlockAchievement(players[0], "First Victory");
                InvitePlayerToGame(players[0], players[1], "Chess Champions");
            }
        }
    }
}