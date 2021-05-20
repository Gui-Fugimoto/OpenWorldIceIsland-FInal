using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainFire : MonoBehaviour
{
    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public int enemyCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);

    }


    // Update is called once per frame
    public void SpawnObject()
    {
        enemyCount += 1;
        Instantiate(spawnee, transform.position, transform.rotation);
        if (enemyCount >= 5)
        {
            stopSpawning = true;
        }
        if (stopSpawning == true)
        {
            CancelInvoke("SpawnObject");

        }
    }
}
