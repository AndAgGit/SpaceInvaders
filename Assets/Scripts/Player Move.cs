using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
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
}
