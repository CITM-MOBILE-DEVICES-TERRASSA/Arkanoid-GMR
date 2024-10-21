using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // Referencia al componente de texto para la puntuaci�n
    public TextMeshProUGUI livesText;  // Referencia al componente de texto para las vidas

    // M�todo para actualizar el texto de la puntuaci�n
    public void UpdateScore(int newScore)
    {
        scoreText.text = "Score: " + newScore.ToString();
    }

    // M�todo para actualizar el texto de las vidas
    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives.ToString();
    }
}
