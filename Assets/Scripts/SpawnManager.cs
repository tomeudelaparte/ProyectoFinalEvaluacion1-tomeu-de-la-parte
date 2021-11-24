using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject coinPrefab;

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(coinPrefab, randomPosition(), coinPrefab.transform.rotation);
        }

        InvokeRepeating("SpawnObstacle", 1f, 5f);
    }

    public Vector3 randomPosition()
    {
        float randomX = Random.Range(-200f, 200f);
        float randomY = Random.Range(0f, 200f);
        float randomZ = Random.Range(-200f, 200f);

        return new Vector3(randomX, randomY, randomZ);
    }

    public void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, randomPosition(), obstaclePrefab.transform.rotation);
    }
}
