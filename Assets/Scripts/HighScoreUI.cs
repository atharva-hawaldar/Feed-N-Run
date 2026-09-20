using UnityEngine;
using TMPro;

public class HighScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = "Score: " + GameMode.Instance.highScore;
    }
}