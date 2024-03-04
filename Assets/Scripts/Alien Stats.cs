using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienStats : MonoBehaviour
{
    public delegate void bulletImpactAction(int value);
    public static event bulletImpactAction onBulletImpact;

    private int value;
    private bool canShoot;
    private Color color;

    public void setType(int type)
    {
        value = type * 10;
        canShoot = type == 3;
        switch (type)
        {
            case 1:
                color = Color.green;
                break;
            case 2:
                color = Color.yellow;
                break;
            case 3:
                color = Color.red;
                break;
            default:
                color = Color.cyan;
                break;
        }

        GetComponent<MeshRenderer>().material.color = color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        onBulletImpact(value);
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }
}
