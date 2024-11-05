using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public StartingScreen StartScreen;
    public Shooting shoot;
    public void Setup() // activates screen and freezes game
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        shoot.DisableShooting();
    }

    public void RestartButton()
    {  //reloads the scene to replay the game
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");

    }
   
}
