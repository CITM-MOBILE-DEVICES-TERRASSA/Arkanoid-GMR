using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives = 3;  
    public int score = 0;  
    public HUD hud;        
    private bool isPaused = false;

    public GameObject pauseUI;

    void Start()
    {
        hud.UpdateLives(lives);
        hud.UpdateScore(score);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePause();
        }
    }

    public void AddPoints(int points)
    {
        score += points;
        hud.UpdateScore(score);  
    }

    public void LosseHealth()
    {
        lives--;  

        hud.UpdateLives(lives);  

        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            ResetLevel();
        }
    }

    public void ResetLevel()
    {
        FindObjectOfType<Ball>().ResetBall();
        FindObjectOfType<Player>().ResetPlayer();
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseUI.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseUI.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseUI.SetActive(false);
        SceneManager.LoadScene("GameMenu");
    }

    public void CheckLevelComplet()
    {
        if (transform.childCount <= 1)
        {
            Scene escenaActual = SceneManager.GetActiveScene();

            if (escenaActual.name == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }
            else
            {
                SceneManager.LoadScene("Level1");
            }
        }
    }
}
