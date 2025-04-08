using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Arme
{
    private string couleur;
    private float healing;

    public string Couleur { get => couleur; set => couleur = value; }
    public float Healing { get => healing; set => healing = value; }

    public override string Attaquer()
    {
        return "Attaque avec un fruit "+this.nom;
    }

    public float Eat()
    {
        return healing;
    }

    public Fruit(string couleur, float healing ,string nom , float degats , RARITY rarete)
    {
        Couleur = couleur;
        Healing = healing;
        Nom = nom;
        Degats = degats;
        Rarete = rarete;
    }

}
