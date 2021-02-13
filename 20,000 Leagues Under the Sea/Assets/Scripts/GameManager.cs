using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _frame;
    private int _score;

    void FixedUpdate() {
        _frame = ((_frame + 1) % 4);

        _score = (_frame == 0) ? _score + 1 : _score;
        // Debug.Log(_score);
    }

    public void AddToScore(int boost)
    {
        _score += boost;
    }
}
