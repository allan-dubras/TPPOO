using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TP3_Polymorphisme
{
    public abstract class Arme : MonoBehaviour
    {
        public string nom;
        private float degats;

        public string Nom { get => nom; set => nom = value; }
        protected float Degats { get => degats; set => degats = value; }

        public abstract void Attack();
    }
}
