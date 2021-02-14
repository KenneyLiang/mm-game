using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    public Text pointsText;

    public void SetUp(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString();


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
