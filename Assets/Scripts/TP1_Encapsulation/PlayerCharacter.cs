using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    // J'ai changer toutes les variable en private car en public tout les script peuvent accèder 
    // et changer les valeurs 
    private string playerName;
    private int health;
    private int maxHealth=100;
    private float moveSpeed;
    private int gold;
    private bool isInvincible;
    private float maxSpeed=10;
    private float Experience=0;
    private float MaxExp=10;
    private int Niveau=0;
    private int pointAttributs= 0;

    //Statistique player
    private int vigor; //vie
    private int mind; //esprit
    private int endurance; //endurance
    private int strength; //force
    private int dexterity; // dextérité
    private int intelligence; // intelligence
    private int faith; //foi 
    private int arcane; //esotérisme



    //Implémentation des getters et setters pour contrôler l'accès aux données 

    //Getters PlayerName
    public string getPlayerName()
    {
        return playerName;
    }
    //Setters PlayerName
    public void setPlayerName(string playerName)
    {
        this.playerName = playerName;
    }

    //Getters  Health
    public int getHealth()
    {
        return health;
    }
    //Setters Health
    public void setHealth(int health)
    {
        this.health = health;
        //Limitation de la max et min valeur
        if (health < 0) { health = 0; }
        if (health > maxHealth) { health = maxHealth; }
    }

    //Getters  MaxHealth
    public int getMaxHealth()
    {
        return maxHealth;
    }
    //Setters MaxHealth
    public void setMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    //Getters  MoveSpeed
    public float getMoveSpeed()
    {
        return moveSpeed;
    }
    //Setters MoveSpeed
    public void setMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
        //Limitation de la max et min valeur
        if (moveSpeed > maxSpeed) { moveSpeed = maxSpeed; }
        if (moveSpeed < 0) { moveSpeed = 1; }
    }
    //Getters  Gold
    public int getGold()
    {
        return gold;
    }
    //Setters  Gold
    public void setGold(int gold)
    {
        this.gold = gold;
        //Limitation de la  min valeur
        if (gold < 0) { gold = 0; }
    }
    //Getters isInvicible
    public bool getIsInvicible()
    {
        return isInvincible;
    }
    //Setters isInvicible
    public void setIsInvicible(bool isInvicible)
    {
        this.isInvincible = isInvicible;
    }
    //méthodes pour prendre des dégats 
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health == 0 && isInvincible == false) { Debug.Log("You Died"); }
    }
    //méthodes pour gagner de l'or
    public void GainGold(int amount)
    {
        gold += amount;
    }
    //méthodes pour dépenser de l'or
    public void LoseGold(int amount)
    {
        gold -= amount;
    }
    //méthodes pour la regen
    public void RegenHealth(int amount)
    {
        health += amount;
    }
    //methodes de L'exp
    public void ExpSystem(int amount)
    {
        Experience += amount;
        if (Experience > MaxExp)
        {
            Experience -= MaxExp ;
            MaxExp *= 2f;
            Niveau++;
            pointAttributs++;
        }
    }
    //Méthodes Stats
    public void StatsSystem(int pointAttributs)
    {
        if (pointAttributs > 0) 
        {
            vigor++;
            mind++;
            endurance++;
            strength++;
            dexterity++;
            intelligence++;
            faith++;
            arcane++;
            pointAttributs--;
        }
    }
    public void Mouvement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }
    private void Start()
    {
        setPlayerName("Artorias");
        setGold(0);
        setHealth(50);
        setMoveSpeed(5);

    }
    private void Update()
    {
        Mouvement();
    }
}