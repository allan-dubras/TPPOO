using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Arme  
{
    public enum RARITY
    {
        LOW,
        MID,
        HIGH,
        EXTREME,
        PEAK,
    }
    protected string nom;
    protected float degats;
    protected RARITY rarete;

    public string Nom { get => nom; set => nom = value; }
    public float Degats { get => degats; set => degats = value; }
    public RARITY Rarete { get => rarete; set => rarete = value; }
    public abstract string Attaquer();
}
