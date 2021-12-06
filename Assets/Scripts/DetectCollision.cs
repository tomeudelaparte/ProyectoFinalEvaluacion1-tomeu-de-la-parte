using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    // Detecta las colisiones entre GameObjects
    private void OnTriggerEnter(Collider otherCollider)
    {
        // Si el proyectil colisiona contra el obst�culo
        if (gameObject.CompareTag("Projectile") && otherCollider.gameObject.CompareTag("Obstacle"))
        {
            // Destruye el proyectil y destruye el obst�culo
            Destroy(gameObject);
            Destroy(otherCollider.gameObject);
        }
    }
}