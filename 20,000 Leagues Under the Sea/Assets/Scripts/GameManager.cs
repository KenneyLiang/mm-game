using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _frame;
    private int _score = 1;

    public float maxSpeed = 8.0f;
    public float speed = 1.0f;

    void Start()
    {
        Time.timeScale = 1.0f;
        speed = 1.0f;
    }

    void FixedUpdate() {
        _frame = ((_frame + 1) % 4);

        _score = (_frame == 0) ? _score + 1 : _score;
        ScoreScript.score = _score;

        if((_score % 75 == 0) && speed < maxSpeed){
            speed += 0.025f;
            Time.timeScale = speed;
            _score++;
        }
    }

    public void AddToScore(int boost)
    {
        _score += boost;
        ScoreScript.score = _score;
    }

    public int getScore()
    {
        return _score;
    }

}
