using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    void Awake()
    {
        Destroy(this.gameObject, 7f);
        transform.GetComponent<Rigidbody>().AddForce(Vector3.down * speed, ForceMode.Impulse);
    }
}
