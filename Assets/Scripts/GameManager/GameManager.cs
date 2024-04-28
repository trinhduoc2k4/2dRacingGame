using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    private int highScore;
    public TextMeshProUGUI highScoreText, scoreText;
    private ScoreManager scoreManager;
    public GameObject gameOverPanel, gameStartPanel;
    public Toggle playPause;
    public static bool isRestart;
    public AudioSource bgSound;
    private void Awake()
    {
        instance = this;    
    }
    private void Start()
    {
        scoreManager = GameManager.FindObjectOfType<ScoreManager>();
        gameOverPanel.SetActive(false);
        Time.timeScale = 0;
        bgSound = GetComponent<AudioSource>();  

        if(isRestart) Play();
    }

    private void Update()
    {
        highScore = PlayerPrefs.GetInt("_highscore");

        highScoreText.text = "High Score: " + highScore.ToString();
        scoreText.text = "Score: " + scoreManager.score.ToString();


        if (playPause.isOn && !PlayerController.instance.isTrigger && !gameStartPanel.activeSelf) Time.timeScale = 1;
        else Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isRestart = true;
    }

    public void Play()
    {
        gameStartPanel.SetActive(false);
        Time.timeScale = 1;
        isRestart = false;
        bgSound.Play();
    }
}
