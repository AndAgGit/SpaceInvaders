using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectWall : MonoBehaviour
{
    public delegate void WallAction();
    public static event WallAction OnWallHit;
    public static event WallAction OnEndGame;

    void Update()
    {
        if (GameOver.GetIsOver())
        {
            return;
        }

        if (AlienMove.GetDirection() > 0 && transform.position.x >= 8.25f || AlienMove.GetDirection() < 0 && transform.position.x <= -8.25f)
        {
            OnWallHit();
        }

        if (transform.position.y > -4.5f)
        {
            return;
        }

        OnEndGame();
    }
}
