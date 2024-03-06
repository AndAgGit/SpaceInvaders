using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public delegate void LogicEvent();
    public static event LogicEvent OnNewRound;
    public static event LogicEvent OnHalfDead;

    private static bool canSpeedUp;
    private static float numAliens, maxAliens;
    void Start()
    {
        canSpeedUp = true;
        AlienStats.onAlienDeath += EvaluateGameState;
    }

    public static void EvaluateGameState(int value)
    {
        numAliens--;

        if (numAliens <= 0)
        {
            Debug.Log("All Dead!");
            OnNewRound();
            canSpeedUp = true;
            return;
        }

        if (!canSpeedUp)
        {
            return;
        }

        if(numAliens <= maxAliens / 2f)
        {
            Debug.Log("Half Dead");
            canSpeedUp = false;
            OnHalfDead();
            return;
        }
    }

    public static void SetNumAliens(int i)
    {
        numAliens = (float)i;
        maxAliens = (float)i;
    }
    public static float GetNumAliens()
    {
        return numAliens;
    }
}
