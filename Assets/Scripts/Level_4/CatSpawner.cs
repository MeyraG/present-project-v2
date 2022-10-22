using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    public GameObject[] cats;
    private Vector3 spawnPos;
    private float repeatTime = 1f;
    private float startDelay = 1f;

    void Start()
    {
        InvokeRepeating("SpawnCats", startDelay, repeatTime);
    }

    void SpawnCats()
    {
        spawnPos = new Vector3(Random.Range(-10,10), 0, 14);
        GameObject cat = Instantiate(cats[Random.Range(0,cats.Length-1)], spawnPos, Quaternion.identity);
        CatsController catsCont = cat.GetComponent<CatsController>();
        catsCont.catScoreController = GetComponent<CatScoreController>();
        //Instantiate(cats[4], spawnPos, Quaternion.identity);
    }
}
