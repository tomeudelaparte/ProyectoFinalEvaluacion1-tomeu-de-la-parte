using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    // Velocidad de translaci�n
    private float speed = 100f;

    // Ejecuta a cada frame
    void Update()
    {
        // Mueve el GameObject hacia delante seg�n la velocidad determinada
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}