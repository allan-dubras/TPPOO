using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue 
{
   //Attributs
  
    private Personne interlocuteur1;
    private Personne interlocuteur2;
    private string contenu;

    public Personne Interlocuteur1 { get => interlocuteur1; set => interlocuteur1 = value; }
    public Personne Interlocuteur2 { get => interlocuteur2; set => interlocuteur2 = value; }
    public string Contenu { get => contenu; set => contenu = value; }

    public Personne getInterlocuteur1()
    {
        return Interlocuteur1;
    }

    public Personne getInterlocuteur2()
    {
        return Interlocuteur2;
    }
    public string getContenu() { return Contenu; }

    public void setInterlocuteur1(Personne value)
    {
        this.Interlocuteur1 = value;
    }

    public void setInterlocuteur2(Personne value)
    {
        this.Interlocuteur2 = value;
    }
    public void setContenu(string value) {
        this.Contenu = value;
    }

    public Dialogue()
    {
        this.Contenu = "Pas de dialogue pour l'instant";
    }
    public Dialogue(string contenu)
    {
        this.Contenu = contenu;
    }
    public Dialogue(Personne interlocuteur1)
    {
        this.Interlocuteur1 = interlocuteur1;
    }
    public Dialogue(Personne interlocuteur1,Personne interlocuteur2)
    {
        this.Interlocuteur1 = interlocuteur1;
        this.Interlocuteur2 = interlocuteur2;
    }
     ~Dialogue()
    {
        int i = 1;
    }




    //Méthodes
}
