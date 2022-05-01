using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreTime : MonoBehaviour
{

    public Text scoreText, timerText, highScoreText;

    [HideInInspector]
    public int score;
    [HideInInspector]
    public int highScore;

    public GameObject endScreen;
    public Text highScoreTextEnd;
    

    float timerMinute, timerSeconds;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highScore = 0;
        timerMinute = 14;
        timerSeconds = 59;

        
    }

    // Update is called once per frame
    void Update()
    {
        countDown();
        updateTextScore();
        updateTimerText();
        updateHighScoreText();

        endGame();
    }

    void updateTextScore()
    {
        scoreText.text = "Score: " + score;
    }

    void updateTimerText()
    {
        timerText.text = "Timer: " + timerMinute + " : " + (int)timerSeconds;
    }

    void updateHighScoreText()
    {
        highScoreText.text = "HighScore: " + highScore;
    }

    void countDown()
    {
        if (timerSeconds <= 59 && timerSeconds >= 0)
            timerSeconds -= Time.deltaTime;
        else if (timerSeconds <= 0)
        {
            timerMinute -= 1;
            timerSeconds = 59;
        }
    }

    void endGame()
    {
        if (timerMinute <= 0 && timerSeconds <= 0)
        {
            Time.timeScale = 0;
           
            endScreen.SetActive(true);
            if (score > highScore)
                highScore = score;

            highScoreTextEnd.text = "HighScore: " + highScore;
        }
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
