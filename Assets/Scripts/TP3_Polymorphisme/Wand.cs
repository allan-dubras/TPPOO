using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TP3_Polymorphisme

{
    public enum TypeWand
    {
        Acacia_Wand,
        Alnus_Wand,
        Fraxinus_Wand,
        Fagus_Wand,
    }
    public  class Wand : Arme
    {
        public Wand()
        {
            Nom = "Wand";
        }
        protected TypeWand types;
        protected TypeWand Types { get => types; set => types = value; }


        public override void Attack()
        {
            Debug.Log("Peak Fiction");
        }
    }

}
