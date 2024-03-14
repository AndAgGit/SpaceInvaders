using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AlienStats : MonoBehaviour
{
    public delegate void alienDeathAction(int value);
    public static event alienDeathAction onAlienDeath;

    public Material baby, sad, mad, rand;

    public GameObject textPrefab, explosionPrefab;

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
                value = (int) Mathf.Floor(Random.Range(2f, 6f)) * 50;
                Destroy(gameObject, 10f);
                break;
        }

        GetComponent<MeshRenderer>().material = mat;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            onAlienDeath(value);

            GameObject scoreAdd = Instantiate(textPrefab, transform.position, Quaternion.identity, null);
            scoreAdd.GetComponent<TextMeshPro>().text = value.ToString();

            GameObject effects = Instantiate(explosionPrefab, transform.position, Quaternion.identity, null);
            Destroy(effects, 1f);

            Destroy(scoreAdd, 0.5f);

            Destroy(collision.gameObject);

            Destroy(gameObject);
        }
    }

    public bool getCanShoot()
    {
        return canShoot;
    }
}
