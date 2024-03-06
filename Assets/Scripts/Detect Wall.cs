using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectWall : MonoBehaviour
{
    public delegate void WallAction();
    public static event WallAction OnWallHit;

    void Update()
    {
        if (AlienMove.GetDirection() > 0 && transform.position.x >= 8.25f || AlienMove.GetDirection() < 0 && transform.position.x <= -8.25f)
        {
            OnWallHit();
        }
    }
}
