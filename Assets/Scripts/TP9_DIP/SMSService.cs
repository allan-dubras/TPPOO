using UnityEngine;

namespace TP9
{
    // SMSService.cs - Module de bas niveau
    public class SMSService : MonoBehaviour
    {
        public void SendSMS(string to, string message)
        {
            Debug.Log($"SMS sent to {to}\nMessage: {message}");
            // In a real implementation, you would integrate with an SMS service here
        }
    }
}