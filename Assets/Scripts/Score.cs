using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private static int score;

    void Start()
    {
        AlienStats.onAlienDeath += addScore;
        score = 0;
    }

    public void addScore(int value)
    {
        score += value;
        Debug.Log(score);
    }
}
