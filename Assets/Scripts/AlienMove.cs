using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMove : MonoBehaviour
{
    public delegate void alienWaitAction();
    public static alienWaitAction OnEndWait;

    public float maxInterval, intervalDecrease, levelDeltaInterval, speedUpDelta, verticalStep, stepSize;
    public Transform alienContainer;

    private static float interval, timer, direction;
    private static bool moveDown, canMove;
    private static float level;


    void Awake()
    {
        canMove = true;
        level = 1;
        interval = maxInterval;
        moveDown = false;
        direction = 1f;
        timer = interval;
        DetectWall.OnWallHit += WallBounce;
        GameLogic.OnNewRound += NewRoundStats;
        GameLogic.OnHalfDead += SpeedUp;
        PlayerMove.OnPlayerDeath += PlayerDeath;
    }
    void Update()
    {
        if (!canMove)
        {
            timer = maxInterval;
            return;
        }

        timer -= Time.deltaTime;

        if (timer > 0f)
        {
            return;
        }

        if (moveDown)
        {
            alienContainer.position += Vector3.down * verticalStep;
            moveDown = false;
            direction *= -1f;
            interval *= intervalDecrease;
            level++;
        }
        else
        {
            alienContainer.position += Vector3.right * direction * stepSize;
        }

        timer = interval;
    }

    public static float GetDirection()
    {
        return direction;
    }

    public static float GetLevel()
    {
        return level;
    }

    public static bool GetMoveDown()
    {
        return moveDown;
    }

    public static void WallBounce()
    {
        moveDown = true;
    }

    public void NewRoundStats()
    {
        moveDown = false;
        interval = maxInterval;
        intervalDecrease *= Mathf.Pow(levelDeltaInterval, level);
    }

    public void SpeedUp()
    {
        Debug.Log("Speeding up");
        interval *= speedUpDelta;
    }

    public void PlayerDeath()
    {
        canMove = false;
        StartCoroutine("BulletDecay");
    }

    IEnumerator BulletDecay()
    {
        float timer = 4f;
        while(timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        canMove = true;
        OnEndWait();
        yield break;
    }
}
