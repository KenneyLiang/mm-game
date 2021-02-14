using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _frame;
    private int _score = 0;

    public float maxSpeed = 2.0f;
    public float speed = 1.0f;


    void FixedUpdate() {
        _frame = ((_frame + 1) % 4);

        _score = (_frame == 0) ? _score + 1 : _score;
        // Debug.Log(_score);

        if((_score % 50 == 0) && speed < maxSpeed){
            speed += 0.1f* Time.deltaTime;
            Time.timeScale = speed;
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
