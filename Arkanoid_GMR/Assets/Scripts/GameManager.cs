using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{


    public int lives = 3;


    public void LosseHealth()
    {

        lives--;

        if (lives <=0)
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

        if (transform.childCount <=1)
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
