using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    public static GameMode Instance; //global access

    public int score = 0;
    public int highScore = 0;
    public bool isGameOver = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

public void AddScore(int amount)
{
    score += amount;

    if(score < 0)
        score = 0;

    if (score > highScore)
    {
        highScore = score;
    }
}
    public void GameOver()
    {
        isGameOver = true;
        SceneManager.LoadScene("GameOverMenu");
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartNew()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void Exit()
    {
        Application.Quit();
    }
}