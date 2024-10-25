using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Brick : MonoBehaviour
{
    public int hitsToDestroy = 3;  
    public int points = 100;  
    private SpriteRenderer spriteRenderer;  
    public GameObject powerUpPrefab;  
    public float powerUpDropChance = 0.2f;  

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  
        UpdateBrickColor();  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            hitsToDestroy--;  

            if (hitsToDestroy <= 0)
            {
                DropPowerUp();
                FindObjectOfType<GameManager>().CheckLevelComplet();
                Destroy(gameObject);  
                FindObjectOfType<GameManager>().AddPoints(points);  

            }
            else
            {
                UpdateBrickColor();  
            }
        }
    }

    private void UpdateBrickColor()
    {
        Color currentColor = spriteRenderer.color;

        float colorFactor = (float)hitsToDestroy / 3f;  
        spriteRenderer.color = new Color(1f, colorFactor, colorFactor);  
    }

    void DropPowerUp()
    {
        if (Random.value < powerUpDropChance)  
        {
            Instantiate(powerUpPrefab, transform.position, Quaternion.identity, null);
        }
    }
}
