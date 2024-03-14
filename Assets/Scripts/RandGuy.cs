using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandGuy : MonoBehaviour
{
    public float maxInterval;
    public Transform leftSpawn, rightSpawn;
    public GameObject guyPrefab;

    private float interval;

    private void Awake()
    {
        interval = maxInterval;
    }

    // Update is called once per frame
    void Update()
    {
        interval -= Time.deltaTime;

        if (interval > 0f)
        {
            return;
        }

        SpawnGuy();

        interval = maxInterval;
    }

    void SpawnGuy()
    {
        GameObject guy;

        bool isLeft = Random.Range(0f, 1f) > 0.5f;

        if (isLeft)
        {
            guy = Instantiate(guyPrefab, leftSpawn.position, Quaternion.identity, null);
            guy.GetComponent<RandGuyMove>().SetDirection(1);

        }
        else
        {
            guy = Instantiate(guyPrefab, rightSpawn.position, Quaternion.identity, null);
            guy.GetComponent<RandGuyMove>().SetDirection(-1);
        }

        guy.GetComponent<AlienStats>().setType(4);
    }
}
