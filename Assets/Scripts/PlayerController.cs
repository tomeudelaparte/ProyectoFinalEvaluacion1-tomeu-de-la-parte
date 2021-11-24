using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 defaultPosition = new Vector3(0, 100, 0);

    public GameObject projectilePrefab;

    private float speed = 30.0f;
    private float horizontalInput;
    private float verticalInput;

    private float range = 200f;

    private int totalCoins = 0;

    void Start()
    {
        transform.position = defaultPosition;
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Coin"))
        {
            Destroy(otherCollider.gameObject);

            totalCoins++;

            if (totalCoins >= 10)
            {
                Debug.Log("¡NICE JOB! WE HAVE ALL THE COINS.");
                Time.timeScale = 0f;
            }
        }
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = -Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        transform.Rotate(Vector3.up * speed * Time.deltaTime * horizontalInput);
        transform.Rotate(Vector3.right * speed * Time.deltaTime * verticalInput);

        if (transform.position.x < -range)
        {
            transform.position = new Vector3(-range, transform.position.y, transform.position.z);
        }

        if (transform.position.x > range)
        {
            transform.position = new Vector3(range, transform.position.y, transform.position.z);
        }

        if (transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }

        if (transform.position.y > range)
        {
            transform.position = new Vector3(transform.position.x, range, transform.position.z);
        }

        if (transform.position.z < -range)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -range);
        }

        if (transform.position.z > range)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, range);
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }
}
