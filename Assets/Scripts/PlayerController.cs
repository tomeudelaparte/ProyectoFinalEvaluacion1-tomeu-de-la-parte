using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Posición predeterminada del player
    private Vector3 defaultPosition = new Vector3(0f, 100f, 0f);

    // Almacena el prefab del proyectil
    public GameObject projectilePrefab;

    // Velocidad de movimiento
    private float speed = 30f;

    // Controles horizontales y verticales del player
    private float horizontalInput;
    private float verticalInput;

    // Rango máximo de movimiento
    private float range = 200f;

    // Total de monedas obtenidas
    private int totalCoins = 0;

    // Total máximo de monedas
    private int maxCoins = 10;

    // Ejecuta al empezar el juego
    void Start()
    {
        // Posiciona el player en la posición predeterminada
        transform.position = defaultPosition;
    }

    // Ejucuta a cada frame
    void Update()
    {
        // Si pulsa la tecla Ctrl Derecho instancia un prefab del proyectil en una posición y rotación determinada
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }

        // Obtiene los controles que se estén usando
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = -Input.GetAxis("Vertical");

        // Mueve el player hacia delante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Rota el player según el eje que se esté utilizando
        transform.Rotate(Vector3.up * speed * Time.deltaTime * horizontalInput);
        transform.Rotate(Vector3.right * speed * Time.deltaTime * verticalInput);

        // Llama a la función para limitar el movimiento en la zona de juego
        movementLimit();
    }

    // Función que comprueba las colisiones del player con otros GameObjects
    private void OnTriggerEnter(Collider otherCollider)
    {
        // Si colisiona contra el obstáculo
        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            // Muestra por consola el mensaje y pausa el juego
            Debug.Log("¡GAME OVER! WE LOST.");
            Time.timeScale = 0f;
        }

        // Si colisiona contra la moneda
        if (otherCollider.gameObject.CompareTag("Coin"))
        {
            // Destruye la moneda
            Destroy(otherCollider.gameObject);

            // Suma +1 al total de monedas obtenidas
            totalCoins++;

            // Si el total de monedas obtenidas es mayor o igual al máximo establecido,
            // muestra un mensaje por consola y se pausa el juego
            if (totalCoins >= maxCoins)
            {
                Debug.Log("¡NICE JOB! WE HAVE ALL THE COINS.");
                Time.timeScale = 0f;
            }
        }
    }

    // Función para limitar el movimiento al player en la zona de juego parecido a unas paredes invisibles
    public void movementLimit()
    {
        // Si la posición X es menor a -200 mueve el player a -200 en X
        if (transform.position.x < -range)
        {
            transform.position = new Vector3(-range, transform.position.y, transform.position.z);
        }

        // Si la posición X es mayor a 200 mueve el player a 200 en X
        if (transform.position.x > range)
        {
            transform.position = new Vector3(range, transform.position.y, transform.position.z);
        }

        // Si la posición Y es menor a 0 mueve el player a 0 en Y
        if (transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }

        // Si la posición Y es mayor a 200 mueve el player a 200 en Y
        if (transform.position.y > range)
        {
            transform.position = new Vector3(transform.position.x, range, transform.position.z);
        }

        // Si la posición Z es menor a -200 mueve el player a -200 en Z
        if (transform.position.z < -range)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -range);
        }

        // Si la posición Z es mayor a 200 mueve el player a 200 en Z
        if (transform.position.z > range)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, range);
        }
    }
}