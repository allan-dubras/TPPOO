using UnityEngine;

namespace TP9
{
    // Player.cs
    public class Player : MonoBehaviour
    {
        [SerializeField] private string playerName;
        [SerializeField] private string email;
        [SerializeField] private string phoneNumber;

        public string Name => playerName;
        public string Email => email;
        public string PhoneNumber => phoneNumber;

        public void Initialize(string name, string email, string phone)
        {
            playerName = name;
            this.email = email;
            phoneNumber = phone;
        }
    }
}