using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI _pointsText;
    public AudioSource gameScreenAudio;

    public void SetUp(int score)
    {
        gameScreenAudio.Stop();
        gameObject.SetActive(true);
        _pointsText.SetText(score.ToString());

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
