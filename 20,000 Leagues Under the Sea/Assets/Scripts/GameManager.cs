using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _frame;
    private int _score = 0;
    private int highScore;
    public float maxSpeed = 8.0f;
    public float speed = 1.0f;
    private bool stopCount = false;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
    }


    void FixedUpdate() {

        if (stopCount == false)
        {

            _frame = ((_frame + 1) % 4);

            _score = (_frame == 0) ? _score + 1 : _score;
            ScoreScript.score = _score;
            UpdateHighScore();

            if ((_score % 80 == 0) && speed < maxSpeed)
            {
                speed += 0.1f * Time.deltaTime;
                Time.timeScale = speed;
            }
        }
    }

    public void AddToScore(int boost)
    {

        if (stopCount == false)
        {
            _score += boost;
            ScoreScript.score = _score;

            UpdateHighScore();
        }
    }   

    

    public void UpdateHighScore()
    {
        if(_score > highScore)
        {
            highScore = _score;

            PlayerPrefs.SetInt("HighScore", highScore);

        }

    }

    public int getScore()
        {
            return _score;
    }

    public int getHighScore()
    {
        return highScore;
    }

    public void setStopCount(bool value)
    {
        stopCount = value;
    }

}
