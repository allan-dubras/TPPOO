using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TP3
{
    public class Sword : Arme
    {
       public Sword() { }
        public override void Attaquer()
        {
            Debug.Log("J'attaque avec une épée ");
        }
    }
}
