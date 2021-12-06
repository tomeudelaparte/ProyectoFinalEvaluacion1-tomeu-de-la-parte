using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Almacena los prefabs del obst�culo y el proyectil
    public GameObject obstaclePrefab, coinPrefab;

    // Variables float para los valores aleatorios de X, Y, Z
    private float randomX, randomY, randomZ;

    // Rango de distancia
    private float range = 200f;

    // Valores para llamar a la funci�n InvokeRepeating
    private float timeStart = 1f;
    private float timeInterval = 5f;

    // Cantidad m�xima de monedas
    private int maxCoins = 10;

    // Ejecuta al empezar el juego
    void Start()
    {
        // Bucle que se ejecuta un n�mero de veces seg�n la cantidad m�xima de monedas
        for (int i = 0; i < maxCoins; i++)
        {
            // Instancia una moneda en una posici�n aleatoria
            Instantiate(coinPrefab, randomPosition(), coinPrefab.transform.rotation);
        }

        // Spawnea un obst�culo cada cierto tiempo
        InvokeRepeating("SpawnObstacle", timeStart, timeInterval);
    }

    // Funci�n que spawnea un obst�culo en una posici�n aleatoria
    public void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, randomPosition(), obstaclePrefab.transform.rotation);
    }

    // Funci�n que devuelve una posici�n aleatoria en X, Y y Z
    public Vector3 randomPosition()
    {
        randomX = Random.Range(-range, range);
        randomY = Random.Range(0f, range);
        randomZ = Random.Range(-range, range);

        return new Vector3(randomX, randomY, randomZ);
    }
}