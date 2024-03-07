using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierHurt : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Bullet"))
        {
            return;
        }

        Destroy(collision.gameObject);
        Destroy(this.gameObject);
    }
}
