using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// , pour faire des heritage de heritage
public class Sword : Arme
{
    private string marque;
    public Sword() { }
    //base fait r�f�rence � la classe m�re 
    public Sword(string nom, float degats, RARITY rarete) 
    {

    }
    public string Balayage()
    {
        return "Balayage par Sword(Sword)" + this.nom;
    }

    public override string Attaquer()
    {
        return "Attque avec �pee";
    }

    public string Marque { get => marque; set => marque = value; }
}
