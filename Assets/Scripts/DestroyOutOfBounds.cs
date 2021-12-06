using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // L�mite de destrucci�n del proyectil
    private float range = 400f;

    // Ejecuta a cada frame
    void Update()
    {
        // Si la posici�n en X, Y o Z supera el l�mite
        if (transform.position.x > range 
            || transform.position.x < -range
            || transform.position.y > range 
            || transform.position.z < -range
            || transform.position.z > range 
            || transform.position.z < -range)
        {
            // Destruye el proyectil
            Destroy(gameObject);
        }
    }
}