using System.Collections;
using System.Collections.Generic;
using TP2_Heritage;
using UnityEngine;

public class SkeletonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabSkeleton;
    void Start()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        GameObject premierSkeleton = Instantiate(prefabSkeleton);
    }

}
