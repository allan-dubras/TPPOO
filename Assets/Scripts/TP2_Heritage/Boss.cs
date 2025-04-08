using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Ennemie
{
    [SerializeField]
    private bool Phase2;
    [SerializeField]
    private bool Phase3;
    [SerializeField]
    private float Timer;

    public Boss(int health, int damage, float speed, float detectionRange, Transform player, bool phase2, bool phase3, float timer)
    {
        Health = health;
        Damage = damage;
        Speed = speed;
        DetectionRange = detectionRange;
        Player = player;
        Phase2 = phase2;
        Phase3 = phase3;
        Timer = timer;
    }

    public void Pse2()
    {
        speed = 6;
    }
    public void OneShot()
    {
        Destroy(Player.gameObject);
    }
      float temps = 0;
    private new void Update()
    {
        base.Update();
        if (Phase3)
        {
            temps=temps + Time.deltaTime;
            if (temps > Timer)
            {
                OneShot();
            }
        }
        if (Phase2)
        {
            Pse2();
        }
    }

}
