using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTime : MonoBehaviour
{

    public Text scoreText, timerText, highScoreText;

    [HideInInspector]
    public int score;
    [HideInInspector]
    public int highScore;
    

    float timerMinute, timerSeconds;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highScore = 0;
        timerMinute = 30;
        timerSeconds = 59;

        
    }

    // Update is called once per frame
    void Update()
    {
        countDown();
        updateTextScore();
        updateTimerText();
        updateHighScoreText();
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
}
