using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;

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
            Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
        }
    }

    public void EnableShooting()
    {
        canShoot = true;
    }
}
