using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabBoss;
    void Start()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        GameObject premierBoss = Instantiate(prefabBoss);
    }
}
