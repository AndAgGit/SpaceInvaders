using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public delegate void PlayerDeathEvent();
    public static PlayerDeathEvent OnPlayerDeath;
    public GameObject deathParticles;

    public float speed;
    public float xMax;
    public float xMin;

    private float moveX;
    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");

        if (transform.position.x < xMax && moveX > 0)
        {
            transform.position += Vector3.right * moveX * speed * Time.deltaTime;
        }

        if (transform.position.x > xMin && moveX < 0)
        {
            transform.position += Vector3.right * moveX * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Bullet"))
        {
            return;
        }

        GameObject effects = Instantiate(deathParticles, transform.position, Quaternion.identity, null);
        Destroy(effects, 3f);

        Debug.Log("Ouch");
        Destroy(other.gameObject);
        Destroy(this.gameObject);

        OnPlayerDeath();
    }
}
