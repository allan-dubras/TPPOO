using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabZombie;
    void Start()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        GameObject premierZombie = Instantiate(prefabZombie);
    }

}
