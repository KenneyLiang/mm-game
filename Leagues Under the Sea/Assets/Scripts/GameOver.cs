using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI scoresText;
    public AudioSource gameScreenAudio;
    public TextMeshProUGUI highScoreText;

    public void SetUp(int score, int highScore)
    {
        gameScreenAudio.Stop();
        gameObject.SetActive(true);

        if(score > highScore)
        {
            highScore = score;
        }

        scoresText.SetText(score.ToString());
        highScoreText.SetText(highScore.ToString());

    }

    // Start is called before the first frame update
    public void playGame()
    {
        SceneManager.LoadScene("MainScene");

    }

    public void quitGame()
    {
        Application.Quit();
    }
}
