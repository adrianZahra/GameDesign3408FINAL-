using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    
    public GameObject enemySmall;
    public GameObject enemyMedium;
    public GameObject enemyLarge;
    float smallSpawnTime = 1f;
    float mediumSpawnTime = 1f;
    float largeSpawnTime = 1f;
    public Transform[] spawnPoints;
    private PlayerHealth playerHealth;
    private GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Start()
    {
        if (roundManager.round < 5)
        {
            InvokeRepeating("SpawnSmallMissle", smallSpawnTime, smallSpawnTime);
        }
    }


    void SpawnSmallMissle()
    {
        if (playerHealth.currentHealth <= 0f) // <-- find the players health
        {
            CancelInvoke("SpawnSmallMissle");
            CancelInvoke("SpawnMediumMissle");
            CancelInvoke("SpawnLargeMissle");
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemySmall, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        if (roundManager.round >= 5 && roundManager.round < 10)
        {
            CancelInvoke("SpawnSmallMissle");
            InvokeRepeating("SpawnMediumMissle", mediumSpawnTime, mediumSpawnTime);
        }

    }

    
    void SpawnMediumMissle()
    {
        if (playerHealth.currentHealth <= 0f) 
        {
            CancelInvoke("SpawnSmallMissle");
            CancelInvoke("SpawnMediumMissle");
            CancelInvoke("SpawnLargeMissle");
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyMedium, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        if (roundManager.round >= 10)
        {
            CancelInvoke("SpawnMediumMissle");
            InvokeRepeating("SpawnLargeMissle", largeSpawnTime, largeSpawnTime);
        }
    }


    void SpawnLargeMissle()
    {
        if (playerHealth.currentHealth <= 0f) 
        {
            CancelInvoke("SpawnSmallMissle");
            CancelInvoke("SpawnMediumMissle");
            CancelInvoke("SpawnLargeMissle");
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyLarge, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
  
}
