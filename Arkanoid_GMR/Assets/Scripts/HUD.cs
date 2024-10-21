using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // Referencia al componente de texto para la puntuación
    public TextMeshProUGUI livesText;  // Referencia al componente de texto para las vidas

    // Método para actualizar el texto de la puntuación
    public void UpdateScore(int newScore)
    {
        scoreText.text = "Score: " + newScore.ToString();
    }

    // Método para actualizar el texto de las vidas
    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives.ToString();
    }
}
