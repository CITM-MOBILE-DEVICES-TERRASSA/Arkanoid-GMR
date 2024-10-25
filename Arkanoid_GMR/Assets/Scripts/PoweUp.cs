using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float fallSpeed = 2f;  
    public float scaleIncreaseAmount = 1.5f;  
    public float duration = 5f;  

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ApplyPowerUp(other.gameObject));

            Destroy(gameObject);
        }
    }

    System.Collections.IEnumerator ApplyPowerUp(GameObject player)
    {
        Vector3 originalScale = player.transform.localScale;
        player.transform.localScale = new Vector3(originalScale.x * scaleIncreaseAmount, originalScale.y, originalScale.z);

        yield return new WaitForSeconds(duration);

        player.transform.localScale = originalScale;
    }
}
