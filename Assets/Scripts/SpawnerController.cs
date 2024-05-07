using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]
    public float SpawningSpeed = 2f;  //hur ofta ska de spawnas

    [SerializeField]
    public GameObject EnemyPrefab;
    public Transform[] SpawnPoints;

    [SerializeField]
    GameObject player;

    float LastSpawnTime;
    void Start()
    {
        SpawningSpeed *= 0.85f; //speed som fiender spawnas med.
    }

    
    void Update()
    {
        if(player == null) return;


        var RandomSpawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        if (LastSpawnTime + SpawningSpeed < Time.time)
        {
            Instantiate(EnemyPrefab, RandomSpawnPoint.position, transform.rotation);
            LastSpawnTime = Time.time;
            //SpawningSpeed *= 0.95f; //gångra med 95% så öks svårigheten med varje zombien som kommmer spawnas.
        }
    }
}
