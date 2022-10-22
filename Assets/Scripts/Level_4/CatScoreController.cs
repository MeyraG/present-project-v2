using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CatScoreController : MonoBehaviour
{
    public int catScore;
    public TextMeshProUGUI catScoreText;

    private void Start()
    {
        GameManager.Instance.isGameActive = true;
    }
    public void GetCatScore()
    {
        catScore++;
        catScoreText.text = "You saved " + catScore + " starving cat";
    }

    void Update()
    {
        if (catScore == 3)
        {
            GameManager.Instance.LevelCompleted();           
        }
    }
}
