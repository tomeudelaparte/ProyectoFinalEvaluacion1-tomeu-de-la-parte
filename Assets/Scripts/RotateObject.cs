using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Velocidad de rotación
    public float speed = 2000f;

    // Ejecuta a cada frame
    void Update()
    {
        // Rota el GameObject en Y según la velocidad determinada
        transform.rotation *= Quaternion.Euler(0, speed * Time.deltaTime, 0);
    }
}