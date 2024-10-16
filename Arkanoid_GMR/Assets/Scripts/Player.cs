using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D ribidbody2D;

    public float moveSpeed = 25;

    private Vector2 direction;
    private Vector2 startPosition;

    private bool isAutoPlay = false; // Control del modo automático

    public GameObject ball; // Referencia a la pelota

    private void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Activar/desactivar el modo automático con la tecla G
        if (Input.GetKeyDown(KeyCode.G))
        {
            isAutoPlay = !isAutoPlay; // Cambiar el estado del modo automático
        }

        if (isAutoPlay)
        {
            AutoPlay();
        }
        else
        {
            ManualPlay();
        }
    }

    // Modo manual
    void ManualPlay()
    {
        float inputValue = Input.GetAxisRaw("Horizontal");

        if (inputValue == 1)
        {
            direction = Vector2.right;
        }
        else if (inputValue == -1)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.zero;
        }

        ribidbody2D.AddForce(direction * moveSpeed * Time.deltaTime * 100);
    }

    // Modo automático: seguir la pelota
    void AutoPlay()
    {
        Vector3 ballPosition = ball.transform.position;
        Vector3 paddlePosition = transform.position;

        // Solo moverse en el eje X hacia la posición de la pelota
        paddlePosition.x = Mathf.MoveTowards(paddlePosition.x, ballPosition.x, moveSpeed * Time.deltaTime);

        transform.position = paddlePosition;
    }

    public void ResetPlayer()
    {
        transform.position = startPosition;
        ribidbody2D.velocity = Vector2.zero;
    }
}
