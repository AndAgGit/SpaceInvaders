using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public delegate void LogicEvent();
    public static event LogicEvent OnNewRound;
    public static event LogicEvent OnHalfDead;
    public static event LogicEvent OnGameOver;

    public GameObject player;

    private static bool canSpeedUp, canQuarterSpeedUp;
    private static float numAliens, maxAliens;
    private static int lives;
    void Awake()
    {
        PlayerSpawn();
        lives = 3;
        canSpeedUp = true;
        canQuarterSpeedUp = true;
        AlienStats.onAlienDeath += EvaluateGameState;
        PlayerMove.OnPlayerDeath += PlayerDeath;
        AlienMove.OnEndWait += PlayerSpawn;
        DetectWall.OnEndGame += EndGame;
    }

    public static void EvaluateGameState(int value)
    {
        numAliens--;

        if (numAliens <= 0)
        {
            Debug.Log("All Dead!");
            OnNewRound();
            canSpeedUp = true;
            canQuarterSpeedUp = true;
            return;
        }

        if (canSpeedUp)
        {
            if (numAliens <= maxAliens / 2f)
            {
                Debug.Log("Half Dead");
                canSpeedUp = false;
                OnHalfDead();
                return;
            }

        }

        if (canQuarterSpeedUp)
        {
            if (numAliens <= maxAliens / 4f)
            {
                Debug.Log("Most are Dead");
                canQuarterSpeedUp = false;
                OnHalfDead();
                return;
            }
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

    public static void PlayerDeath()
    {
        lives--;
        
        if(lives < 0)
        {
            EndGame();
        }

    }

    public void PlayerSpawn()
    {
        Instantiate(player, new Vector3(0f, -4.5f, 0f), Quaternion.identity, null);
    }

    public static void EndGame()
    {
        Debug.Log("Game Over");
        OnGameOver();
    }

    public static int GetLives()
    {
        return lives;
    }
}
