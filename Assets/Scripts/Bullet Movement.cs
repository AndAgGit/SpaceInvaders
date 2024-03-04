using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public delegate void BulletAction();
    public static event BulletAction onBulletImpact;

    public float speed;
    private void Awake()
    {
        Destroy(gameObject, 1.5f);
        GetComponent<Rigidbody>().AddForce(Vector3.up * speed, ForceMode.Impulse);
    }

    private void OnDestroy()
    {
        onBulletImpact();
    }
}
