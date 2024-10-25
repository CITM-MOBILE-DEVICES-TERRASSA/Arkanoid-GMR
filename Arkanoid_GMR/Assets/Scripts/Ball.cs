using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;

    public float initialSpeed = 300; 
    public float speedIncrease = 50; 
    public float maxSpeed = 600;     

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
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            FindAnyObjectByType<GameManager>().LosseHealth();
        }
        else
        {
            IncreaseSpeed(); 
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

    void IncreaseSpeed()
    {
        Vector2 currentVelocity = rigidBody2D.velocity;

        float currentSpeed = currentVelocity.magnitude; 
        float newSpeed = Mathf.Min(currentSpeed + speedIncrease, maxSpeed); 

        rigidBody2D.velocity = currentVelocity.normalized * newSpeed;
    }

    public void ResetBall()
    {
        transform.position = startPosition;
        rigidBody2D.velocity = Vector2.zero;

        velocity.x = Random.Range(-1f, 1f);
        velocity.y = 1;

        rigidBody2D.AddForce(velocity * initialSpeed);
    }
}
