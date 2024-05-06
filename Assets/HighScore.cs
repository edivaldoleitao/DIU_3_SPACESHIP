using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    private int highScoreValue = 0;
    Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore = GetComponent<Text>();
        if (Score.scoreValue > highScoreValue)
        {
            highScoreValue = Score.scoreValue;
            highScore.text = "High Score - " + highScoreValue;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        highScore.text = "High Score - " + highScoreValue;
    }
}
