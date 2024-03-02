using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectWall : MonoBehaviour
{
    public delegate void WallAction();
    public static event WallAction OnWallHit;

    void Update()
    {
        if (AlienMove.getDirection() > 0 && transform.position.x >= 8.25f || AlienMove.getDirection() < 0 && transform.position.x <= -8.25f)
        {
            OnWallHit();
        }
    }
}
