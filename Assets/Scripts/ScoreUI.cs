using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = "Score: " + GameMode.Instance.score;
    }
}