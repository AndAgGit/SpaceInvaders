using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandGuyMove : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    public void SetDirection(int i) //1 for right, -1 for left
    {
        speed = Mathf.Abs(speed);
        speed *= i;
    }
}
