using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI scoreText, liveText;
    void Update()
    {
        string score = Score.GetScore().ToString();
        if(score.Length < 4)
        {
            score = score.PadLeft(4, '0');
        }

        int lives = GameLogic.GetLives() + 1;

        scoreText.text = "Score: " + score;
        liveText.text = lives +" :Lives";
    }
}
