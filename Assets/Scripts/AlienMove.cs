using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMove : MonoBehaviour
{
    public float interval, intervalDecrease, verticalStep, stepSize;
    public Transform alienContainer;

    private static float timer, direction;
    private static bool moveDown;

    void Start()
    {
        moveDown = false;
        direction = 1f;
        DetectWall.OnWallHit += wallBounce;
    }
    void Update()
    {
        if(timer <= 0f)
        {
            if (moveDown)
            {
                alienContainer.position += Vector3.down * verticalStep;
                moveDown = false;
                interval *= intervalDecrease;
            }
            else
            {
                alienContainer.position += Vector3.right * direction * stepSize;
            }
            timer = interval;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    public static float getDirection()
    {
        return direction;
    }

    public static void wallBounce()
    {
        direction *= -1f;
        moveDown = true;
    }
}
