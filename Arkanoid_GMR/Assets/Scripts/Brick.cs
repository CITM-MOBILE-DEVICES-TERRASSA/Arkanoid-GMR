using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hitsToDestroy = 3;  // Número de toques necesarios para destruir el brick
    public int points = 100;  // Puntos que este ladrillo otorga
    private SpriteRenderer spriteRenderer;  // Referencia al componente SpriteRenderer

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // Obtener el componente SpriteRenderer
        UpdateBrickColor();  // Establecer el color inicial basado en los toques restantes
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            hitsToDestroy--;  // Reducir el número de toques restantes

            if (hitsToDestroy <= 0)
            {
                
                FindObjectOfType<GameManager>().CheckLevelComplet();
                Destroy(gameObject);  // Destruir el brick cuando los toques llegan a 0
                FindObjectOfType<GameManager>().AddPoints(points);  // Otorgar puntos al destruir el ladrillo

            }
            else
            {
                UpdateBrickColor();  // Aclarar el color con cada toque
            }
        }
    }

    // Método para actualizar el color del brick basado en los toques restantes
    private void UpdateBrickColor()
    {
        // Obtener el color actual
        Color currentColor = spriteRenderer.color;

        // Aclarar el color progresivamente (más cercano al blanco con cada toque)
        float colorFactor = (float)hitsToDestroy / 3f;  // Suponiendo 3 como el número máximo de toques inicial
        spriteRenderer.color = new Color(1f, colorFactor, colorFactor);  // Ajustar el color a medida que se reduce hitsToDestroy
    }
}
