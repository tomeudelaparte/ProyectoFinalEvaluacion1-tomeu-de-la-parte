using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (gameObject.CompareTag("Projectile") && otherCollider.gameObject.CompareTag("Obstacle") )
        {
            Destroy(gameObject);
            Destroy(otherCollider.gameObject);
        }

        if (gameObject.CompareTag("Obstacle") && otherCollider.gameObject.CompareTag("Player"))
        {
            Debug.Log("¡GAME OVER! WE LOST.");
            Time.timeScale = 0f;
        }
    }
}
