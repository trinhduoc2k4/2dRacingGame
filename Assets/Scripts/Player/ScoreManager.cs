using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    private int highScore;
    public TextMeshProUGUI scoreText, _highScore;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("_highscore", 0);
        _highScore.text = "HighScore: " + highScore.ToString(); 
    }

    private void Update()
    {
        scoreText.text = score.ToString();
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("_highscore", highScore);
        }
    }
    public void UpdateScore()
    {
        score++;
    }
}
