using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawn : MonoBehaviour
{
    public GameObject alien;
    public Transform alienContainer;

    [Space]
    [Range(1,20)]
    public int cols;

    private void Start()
    {
        Spawn();
        GameLogic.OnNewRound += Spawn;
    }

    public void Spawn()
    {
        alienContainer.position = new Vector3(0f, 0.5f - (0.5f * AlienMove.GetLevel()), 0f);

        for(float i = 0; i < cols; i++)
        {
            for(float n = 1; n < 6; n++)
            {
                Vector3 setPos = alienContainer.position + Vector3.up * (n - 1) * 0.75f + Vector3.left * (i - ((float)cols / 2f) + 0.5f) * 0.75f;
                GameObject newGuy = Instantiate(alien, setPos, Quaternion.identity, alienContainer);
                newGuy.GetComponent<AlienStats>().setType((int)Mathf.Ceil(n / 2f));
            }
        }
        GameLogic.SetNumAliens(5 * cols);
    }
}
