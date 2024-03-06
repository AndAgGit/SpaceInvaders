using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMove : MonoBehaviour
{
    public float maxInterval, intervalDecrease, levelDeltaInterval, speedUpDelta, verticalStep, stepSize;
    public Transform alienContainer;

    private static float interval, timer, direction;
    private static bool moveDown;
    private static float level;

    void Start()
    {
        level = 1;
        interval = maxInterval;
        moveDown = false;
        direction = 1f;
        timer = interval;
        DetectWall.OnWallHit += WallBounce;
        GameLogic.OnNewRound += NewRoundStats;
        GameLogic.OnHalfDead += SpeedUp;
    }
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer > 0f)
        {
            return;
        }

        if (moveDown)
        {
            alienContainer.position += Vector3.down * verticalStep;
            moveDown = false;
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

    public static void WallBounce()
    {
        direction *= -1f;
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
}
