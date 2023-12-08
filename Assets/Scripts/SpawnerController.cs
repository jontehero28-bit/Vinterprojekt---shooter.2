using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]
    float SpawningSpeed = 2f;  //hur ofta ska de spawnas

    [SerializeField]
    public GameObject Enemy;
    public Transform[] SpawnPoints;

    float LastSpawnTime;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
