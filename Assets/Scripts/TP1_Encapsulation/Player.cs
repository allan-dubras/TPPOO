using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    //Attributs
    private long id;
    private string name;
    private string description;
    private float pointDeVie;

    public long getId()
    {
        return id;
    }
    public void setId(long id)
    {
        this.id = id;
    }
    public string getName() 
    {
        return name;
    }
    public void setName(string name) 
    { 
        this.name = name;
    }
    public string getDescription()
    {
        return description;
    }
    public void setDescription(string description) 
    {
        this.description = description;
    }
    public float getPointDeVie()
    {
        return pointDeVie;
    }
    public void setPointDeVie(float pointDeVie) 
    {
        this.pointDeVie = pointDeVie;
        if (pointDeVie < 0) { pointDeVie = 0; }
    }
}
