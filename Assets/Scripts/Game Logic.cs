using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    void Start()
    {
        BulletMovement.onBulletImpact += evaluateGameState;
    }

    public void evaluateGameState()
    {

    }
}
