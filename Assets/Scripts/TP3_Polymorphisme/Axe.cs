using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TP3_Polymorphisme
{
    public class Axe : Arme
    {
        public Axe()
        {
            Nom = "Axe";
        }
        public override void Attack()
        {
            Debug.Log("High Fiction");
        }
    }


}
