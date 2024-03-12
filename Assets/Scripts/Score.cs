using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private static int score;

    void Start()
    {
        AlienStats.onAlienDeath += AddScore;
        GameLogic.OnGameOver += SaveScore;
        score = 0;
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log(score);
    }

    public static int GetScore()
    {
        return score;
    }

    public void SaveScore()
    {
        if(score <= PlayerPrefs.GetInt("score"))
        {
            return;
        }

        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
    }
}
