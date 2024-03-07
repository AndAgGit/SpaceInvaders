using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;

    private bool canShoot;

    private void Start()
    {
        BulletMovement.onBulletImpact += EnableShooting;
        canShoot = true;
    }
    void Update()
    {
        if(canShoot && Input.GetKey(KeyCode.Space))
        {
            canShoot = false;
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    public void EnableShooting()
    {
        canShoot = true;
    }
}
