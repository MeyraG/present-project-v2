using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreController : MonoBehaviour
{
    public int collectibleLogo;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        
    }
    public void GetCollectible()
    {
        collectibleLogo++;
        scoreText.text = "Score: " + collectibleLogo;
    }

    void Update()
    {
        
    }
}
