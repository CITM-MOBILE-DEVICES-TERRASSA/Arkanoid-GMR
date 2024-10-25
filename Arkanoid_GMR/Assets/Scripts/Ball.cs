using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;

    public float initialSpeed = 300; // Velocidad inicial
    public float speedIncrease = 50; // Incremento de velocidad por colisi�n
    public float maxSpeed = 600;     // Velocidad m�xima

    private Vector2 velocity;
    private Vector2 startPosition;

    public AudioSource audioSource;

    public AudioClip playerSound, brickSound;

    void Start()
    {
        startPosition = transform.position;
        ResetBall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si colisiona con la "DeadZone", llamar a la funci�n de p�rdida de vida
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            FindAnyObjectByType<GameManager>().LosseHealth();
        }
        else
        {
            IncreaseSpeed(); // Aumentar la velocidad en cada colisi�n
        }
        if (collision.gameObject.GetComponent<Player>()){
            audioSource.clip=playerSound;
            audioSource.Play();
        }  
        if (collision.gameObject.GetComponent<Brick>()){
            audioSource.clip=brickSound;
            audioSource.Play();
        }
    }

    // Aumentar la velocidad de la pelota hasta un l�mite m�ximo
    void IncreaseSpeed()
    {
        // Obtener la velocidad actual
        Vector2 currentVelocity = rigidBody2D.velocity;

        // Aumentar la velocidad en la misma direcci�n, respetando el l�mite m�ximo
        float currentSpeed = currentVelocity.magnitude; // Magnitud de la velocidad actual
        float newSpeed = Mathf.Min(currentSpeed + speedIncrease, maxSpeed); // Nueva velocidad con l�mite

        // Mantener la misma direcci�n pero con la nueva velocidad
        rigidBody2D.velocity = currentVelocity.normalized * newSpeed;
    }

    public void ResetBall()
    {
        transform.position = startPosition;
        rigidBody2D.velocity = Vector2.zero;

        // Generar una direcci�n inicial aleatoria
        velocity.x = Random.Range(-1f, 1f);
        velocity.y = 1;

        // Aplicar la velocidad inicial
        rigidBody2D.AddForce(velocity * initialSpeed);
    }
}
