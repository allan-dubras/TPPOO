using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TP3_Polymorphisme
{
    public enum TypeBow
    {
        Longbows,
        Self_bows,
        Composite_bows,
        Reflex_bows,
    }
    public  class Bow : Arme
    {
        protected TypeBow types;
        protected TypeBow Types { get => types; set => types = value; }

        public Bow() 
        {
            Nom = "Bow";
        }
        public override void Attack()
        {
            Debug.Log("Mid Fiction");
        }

    }

}
