using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    // public GameManager gm;
    public static int score = 0;
    private Text txt;
    // Start is called before the first frame update
    void Start()
    {
        // gm = GetComponent<GameManager>();
        txt = GetComponent<Text>();

        txt.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Score: " + score;
    }
}
