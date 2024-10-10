using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemyPrefabs;
    public GameObject powerUpPrefab;
    private float zBound = 9f;
    private float spawnRange = 7f;
    private float zPowerUpRange = 5f;
    private float ySpawn = 0.75f;

    private float enemySpawnTime = 1f;

    private float powerupSpawnTime = 5f;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, enemySpawnTime);
        InvokeRepeating("SpawnPowerUp", 1f, powerupSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        int index = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[index], new Vector3(GetRandomLocation(spawnRange), ySpawn, zBound), enemyPrefabs[index].transform.rotation);
    }

    void SpawnPowerUp()
    {
        Instantiate(powerUpPrefab, new Vector3(GetRandomLocation(spawnRange), ySpawn, GetRandomLocation(zPowerUpRange)), powerUpPrefab.transform.rotation);
    }

    float GetRandomLocation(float val)
    {
        return Random.Range(-val, val);
    }
}
