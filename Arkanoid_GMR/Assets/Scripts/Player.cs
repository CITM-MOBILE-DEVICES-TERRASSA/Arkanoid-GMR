using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    

    public Rigidbody2D ribidbody2D;

    private float inputValue;

    public float moveSpeed = 25;

    private Vector2 direction;

    Vector2 startPosition;

    private void Start()
    {
        startPosition = transform.position;

    }
    // Update is called once per frame
    void Update()
    {

        inputValue = Input.GetAxisRaw("Horizontal");

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

    public void ResetPlayer()
    {

        transform.position = startPosition;
        ribidbody2D.velocity = Vector2.zero;
    }

}

