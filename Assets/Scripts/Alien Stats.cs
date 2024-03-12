using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienStats : MonoBehaviour
{
    public delegate void alienDeathAction(int value);
    public static event alienDeathAction onAlienDeath;

    public Material baby, sad, mad, rand;

    private int value;
    private bool canShoot;
    private Material mat;

    public void setType(int type)
    {
        value = type * 10;
        canShoot = type == 3;
        switch (type)
        {
            case 1:
                mat = baby;
                break;
            case 2:
                mat = sad;
                break;
            case 3:
                mat = mad;
                break;
            default:
                mat = rand;
                break;
        }

        GetComponent<MeshRenderer>().material = mat;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            onAlienDeath(value);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    public bool getCanShoot()
    {
        return canShoot;
    }
}
