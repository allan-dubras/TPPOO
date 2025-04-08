using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP2 : MonoBehaviour
{
    void Start()
    {
        //Arme premiere = new Arme();
        Sword deuxieme = new Sword("Character Developpement",1500f,Arme.RARITY.PEAK);
        //Arme troisieme = new Arme("ONE PIECE",1f,Arme.RARITY.LOW);
       //Debug.Log(premiere.Attaquer());
        Debug.Log(deuxieme.Attaquer());
        Debug.Log(deuxieme.Balayage());
        //Debug.Log(troisieme.Attaquer());
        Fruit premierfruit = new Fruit("rouge",50f,"Pomme",1f,Arme.RARITY.LOW);
        Debug.Log(premierfruit.Attaquer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
