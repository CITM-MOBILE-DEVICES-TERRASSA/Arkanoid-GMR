using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    private bool isPaused = false; // Variable para verificar si el juego está en pausa

    public GameObject pauseUI;

    void Update()
    {
        // Si se presiona la tecla Escape, se alterna el estado de pausa
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePause();
        }
    }

    // Método para alternar la pausa del juego
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

    // Pausar el juego
    public void PauseGame()
    {
        Time.timeScale = 0f; // Detiene el tiempo del juego
        isPaused = true;
        // Aquí podrías mostrar el menú de pausa si tienes uno
        pauseUI.SetActive(true);
    }

    // Reanudar el juego
    public void ResumeGame()
    {
        Time.timeScale = 1f; // Restablece el tiempo del juego
        isPaused = false;
        pauseUI.SetActive(false);
        // Aquí podrías ocultar el menú de pausa si tienes uno
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseUI.SetActive(false);
        SceneManager.LoadScene("GameMenu");

    }

    public void LosseHealth()
    {
        lives--;

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
