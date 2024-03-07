using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject alienBullet;
    public float chance, minInterval, maxInterval;

    private float interval;
    private bool canShoot;

    void Awake()
    {
        canShoot = true;
        interval = Random.Range(minInterval, maxInterval);
        PlayerMove.OnPlayerDeath += DisableShoot;
        AlienMove.OnEndWait += EnableShoot;
    }

    void Update()
    {
        if (!GetComponent<AlienStats>().getCanShoot() || !canShoot)
        {
            return;
        }

        interval -= Time.deltaTime;

        if(interval > 0f)
        {
            return;
        }

        interval = Random.Range(minInterval, maxInterval);

        if (Random.Range(0f, 100f) < chance)
        {
            Instantiate(alienBullet, transform.position, Quaternion.identity, null);
        }
    }

    public void EnableShoot()
    {
        canShoot = true;
    }

    public void DisableShoot()
    {
        canShoot = false;
    }
}
