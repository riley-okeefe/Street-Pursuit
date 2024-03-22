using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoEnemySpawnScript : MonoBehaviour
{
    public GameObject npc;
    private float spawnTimer;
    private Boolean firstWaveSpawned = false,
        secondWaveSpawned = false,
        lastWaveSpawned = false;

    //private Vector3 spawnPosition1 = new Vector3(-25f, 1f, -25f),
    //    spawnPostition2 = new Vector3(25f, 1f, 25f);
    public Vector3 spawnPosition1;
    public Vector3 spawnPosition2;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time - spawnTimer > 15)
        {
            if (!firstWaveSpawned)
            {
                SpawnEnemy(spawnPosition1);
                Debug.Log("First wave spawned at spawn position 1.");
                firstWaveSpawned = true;
            }
        }

        if (Time.time - spawnTimer > 30)
        {
            if (!secondWaveSpawned)
            {
                SpawnEnemy(spawnPosition1);
                Debug.Log("Second wave spawned at spawn position 1.");
                secondWaveSpawned = true;
            }
        }

        if (Time.time - spawnTimer > 45)
        {
            if (!lastWaveSpawned)
            {
                SpawnEnemy(spawnPosition1);
                Debug.Log("Last wave spawned at spawn position 1.");
                SpawnEnemy(spawnPosition2);
                Debug.Log("Last wave spawned at spawn position 2.");
                lastWaveSpawned = true;
            }
        }
    }

    public void SpawnEnemy(Vector3 spawnPoint)
    {
        GameObject newEnemy = Instantiate(npc);
        newEnemy.transform.position = spawnPoint;
    }
}
