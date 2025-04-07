using UnityEngine;

namespace TP9
{
    // EmailService.cs - Module de bas niveau
    public class EmailService : MonoBehaviour
    {
        public void SendEmail(string to, string subject, string message)
        {
            Debug.Log($"Email sent to {to}\nSubject: {subject}\nMessage: {message}");
            // In a real implementation, you would integrate with an email service here
        }
    }
}