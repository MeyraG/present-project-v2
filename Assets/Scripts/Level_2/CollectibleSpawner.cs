using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectible;
    public float respawnTime;
    public float startDelay;
    private Vector3 spawnPosition;
    void Start()
    {
        InvokeRepeating("SpawnCollectible", startDelay, respawnTime);
    }

    private void SpawnCollectible()
    {
        spawnPosition = new Vector3(Random.Range(6, -6), -1, Random.Range(-30, 580));
        Instantiate(collectible, spawnPosition, transform.rotation);
    }
    void Update()
    {
        
    }
}
