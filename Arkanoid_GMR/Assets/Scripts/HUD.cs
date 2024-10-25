using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  
    public TextMeshProUGUI livesText;  

    public void UpdateScore(int newScore)
    {
        scoreText.text = "Score: " + newScore.ToString();
    }

    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives.ToString();
    }
}
