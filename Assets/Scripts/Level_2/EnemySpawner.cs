using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private Vector3 spawnPos;
    [SerializeField]
    private float repeatTime;
    [SerializeField]           
    private float startDelay;
   
    public Transform playerTransform;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, repeatTime);
    }

    void SpawnEnemy()
    {
        spawnPos = new Vector3(Random.Range(-2,2) * 3.5f, 0, Random.Range(400f, 500f));
        GameObject enemyTaxi = Instantiate(enemy, spawnPos, enemy.transform.rotation);
        Destroyer destroyer = enemyTaxi.GetComponent<Destroyer>();
       //Bu scriptte playeri destroyerin playerina atiyoruz:
        destroyer.player = playerTransform;
    }
}
