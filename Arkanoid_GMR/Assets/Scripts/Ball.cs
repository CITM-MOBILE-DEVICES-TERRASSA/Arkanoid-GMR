using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;

    public float initialSpeed = 300; // Velocidad inicial
    public float speedIncrease = 50; // Incremento de velocidad por colisión
    public float maxSpeed = 600;     // Velocidad máxima

    private Vector2 velocity;
    private Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
        ResetBall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si colisiona con la "DeadZone", llamar a la función de pérdida de vida
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            FindAnyObjectByType<GameManager>().LosseHealth();
        }
        else
        {
            IncreaseSpeed(); // Aumentar la velocidad en cada colisión
        }
    }

    // Aumentar la velocidad de la pelota hasta un límite máximo
    void IncreaseSpeed()
    {
        // Obtener la velocidad actual
        Vector2 currentVelocity = rigidBody2D.velocity;

        // Aumentar la velocidad en la misma dirección, respetando el límite máximo
        float currentSpeed = currentVelocity.magnitude; // Magnitud de la velocidad actual
        float newSpeed = Mathf.Min(currentSpeed + speedIncrease, maxSpeed); // Nueva velocidad con límite

        // Mantener la misma dirección pero con la nueva velocidad
        rigidBody2D.velocity = currentVelocity.normalized * newSpeed;
    }

    public void ResetBall()
    {
        transform.position = startPosition;
        rigidBody2D.velocity = Vector2.zero;

        // Generar una dirección inicial aleatoria
        velocity.x = Random.Range(-1f, 1f);
        velocity.y = 1;

        // Aplicar la velocidad inicial
        rigidBody2D.AddForce(velocity * initialSpeed);
    }
}
