using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Almacena los prefabs del obstáculo y el proyectil
    public GameObject obstaclePrefab, coinPrefab;

    // Variables float para los valores aleatorios de X, Y, Z
    private float randomX, randomY, randomZ;

    // Rango de distancia
    private float range = 200f;

    // Valores para llamar a la función InvokeRepeating
    private float timeStart = 1f;
    private float timeInterval = 5f;

    // Cantidad máxima de monedas
    private int maxCoins = 10;

    // Ejecuta al empezar el juego
    void Start()
    {
        // Bucle que se ejecuta un número de veces según la cantidad máxima de monedas
        for (int i = 0; i < maxCoins; i++)
        {
            // Instancia una moneda en una posición aleatoria
            Instantiate(coinPrefab, randomPosition(), coinPrefab.transform.rotation);
        }

        // Spawnea un obstáculo cada cierto tiempo
        InvokeRepeating("SpawnObstacle", timeStart, timeInterval);
    }

    // Función que spawnea un obstáculo en una posición aleatoria
    public void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, randomPosition(), obstaclePrefab.transform.rotation);
    }

    // Función que devuelve una posición aleatoria en X, Y y Z
    public Vector3 randomPosition()
    {
        randomX = Random.Range(-range, range);
        randomY = Random.Range(0f, range);
        randomZ = Random.Range(-range, range);

        return new Vector3(randomX, randomY, randomZ);
    }
}