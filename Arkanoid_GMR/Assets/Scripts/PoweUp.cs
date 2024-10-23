using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float fallSpeed = 2f;  // Velocidad de ca�da del power-up
    public float scaleIncreaseAmount = 1.5f;  // Factor de crecimiento de la plataforma
    public float duration = 5f;  // Duraci�n del efecto del power-up

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

            // Destruir el power-up despu�s de aplicarlo
            Destroy(gameObject);
        }
    }

    System.Collections.IEnumerator ApplyPowerUp(GameObject player)
    {
        // Aumentar el tama�o de la plataforma
        Vector3 originalScale = player.transform.localScale;
        player.transform.localScale = new Vector3(originalScale.x * scaleIncreaseAmount, originalScale.y, originalScale.z);

        // Esperar por la duraci�n del efecto
        yield return new WaitForSeconds(duration);

        // Restaurar el tama�o original de la plataforma
        player.transform.localScale = originalScale;
    }
}
