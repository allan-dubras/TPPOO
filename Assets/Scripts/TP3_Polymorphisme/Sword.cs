using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TP3_Polymorphisme
{
    public enum TypeSword
    {
        Two_handed_sword,
        Greatsword,
        Claymore,
        Zweihänder,
        Katana,
    }
    public  class Sword : Arme
    {
        public Sword()
        {
            Nom = "Sword";
        }
        protected TypeSword types;
        protected TypeSword Types { get => types; set => types = value; }

        public override void Attack()
        {
            Debug.Log("Low Fiction");
        }
    }
}
