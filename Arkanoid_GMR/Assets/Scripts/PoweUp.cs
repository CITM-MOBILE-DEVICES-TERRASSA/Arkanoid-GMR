using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float fallSpeed = 2f;  // Velocidad de caída del power-up
    public float scaleIncreaseAmount = 1.5f;  // Factor de crecimiento de la plataforma
    public float duration = 5f;  // Duración del efecto del power-up

    void Update()
    {
        // Hacer que el power-up caiga hacia abajo
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Aplicar el efecto de agrandar la plataforma
            StartCoroutine(ApplyPowerUp(other.gameObject));

            // Destruir el power-up después de aplicarlo
            Destroy(gameObject);
        }
    }

    System.Collections.IEnumerator ApplyPowerUp(GameObject player)
    {
        // Aumentar el tamaño de la plataforma
        Vector3 originalScale = player.transform.localScale;
        player.transform.localScale = new Vector3(originalScale.x * scaleIncreaseAmount, originalScale.y, originalScale.z);

        // Esperar por la duración del efecto
        yield return new WaitForSeconds(duration);

        // Restaurar el tamaño original de la plataforma
        player.transform.localScale = originalScale;
    }
}
