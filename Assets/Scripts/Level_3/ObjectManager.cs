using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ObjectManager : MonoBehaviour
{

    public List<GameObject> objects;
    private float spawnRate = 1.7f;

    public TextMeshProUGUI scoreText;
    public int score;

    void Start()
    {
        GameManager.Instance.isGameActive = true;
        StartCoroutine(SpawnObjects());
        score = 0;
        ScoreUpdate(0);
    }

    public void ScoreUpdate(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "SCORE : " + score;
    }

    IEnumerator SpawnObjects()
    {
        while (GameManager.Instance.isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, objects.Count);
            Instantiate(objects[index]);
        }
    }
}
