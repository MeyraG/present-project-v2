using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] 
    private GameObject levelCompleteUI;
    [SerializeField]
    private float nextLevelDelay = 3.0f;
    [SerializeField]
    private float restartGameDelay = 15.0f;

    public TextMeshProUGUI failText;
    public bool isGameActive;
 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
           // DontDestroyOnLoad(gameObject);
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
      
    }

    public void StartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LevelCompleted()
    {
        levelCompleteUI.SetActive(true);
        StartCoroutine(LoadNextLevel());
        isGameActive = false;
    }

    //private bool gameHasEnded;

    public void LevelFailed()
    {
        if (isGameActive)
        {
            failText.gameObject.SetActive(true);
            isGameActive = false;

            Invoke(nameof(RestartLevel), restartGameDelay);
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(nextLevelDelay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //void EndTheGame()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name"The End");
    //}

    public void Quit()
    {
        Debug.Log("Quit");

#if UNITY_EDITOR

        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}