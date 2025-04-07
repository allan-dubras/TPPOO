using UnityEngine;
using System.Collections.Generic;

namespace TP9
{
    // NotificationService.cs - Service utilisant les modules de bas niveau
    public class NotificationService : MonoBehaviour
    {
        private EmailService emailService;
        private SMSService smsService;

        private void Awake()
        {
            emailService = GetComponent<EmailService>();
            if (emailService == null)
            {
                emailService = gameObject.AddComponent<EmailService>();
            }

            smsService = GetComponent<SMSService>();
            if (smsService == null)
            {
                smsService = gameObject.AddComponent<SMSService>();
            }
        }

        public void NotifyPlayerAchievementUnlocked(Player player, string achievementName)
        {
            string message = $"Congratulations! You've unlocked the achievement: {achievementName}";
            
            // Send email notification
            emailService.SendEmail(player.Email, "Achievement Unlocked!", message);
            
            // Send SMS notification
            smsService.SendSMS(player.PhoneNumber, message);
            
            Debug.Log($"Notification sent to {player.Name} for achievement: {achievementName}");
        }

        public void NotifyPlayerGameInvite(Player inviter, Player invitee, string gameName)
        {
            string message = $"{inviter.Name} has invited you to play {gameName}!";
            
            // Send email notification
            emailService.SendEmail(invitee.Email, "Game Invitation", message);
            
            // Send SMS notification
            smsService.SendSMS(invitee.PhoneNumber, message);
            
            Debug.Log($"Game invite notification sent from {inviter.Name} to {invitee.Name}");
        }
    }
}