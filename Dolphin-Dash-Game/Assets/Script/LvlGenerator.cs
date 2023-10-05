using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlGenerator : MonoBehaviour
{
    private Transform LastPoint;
    [SerializeField] private GameObject[] Prefab;
    [SerializeField] private GameObject OGPlatform;

    private void Awake()
    {
        LastPoint = OGPlatform.transform.Find("EndPoint");
    }

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            int num = Random.Range(0, 2);
            generateWaves(num);
        }
    }

    //private void Update()
    //{
        
    //}


    private void generateWaves(int num)
    {
        Transform newEnd = Instantiate(Prefab[num], LastPoint.position, Quaternion.identity).transform;
        LastPoint = newEnd.Find("EndPoint").transform;
    }
}
