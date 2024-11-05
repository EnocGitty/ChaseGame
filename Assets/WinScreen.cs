using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WinScreen : MonoBehaviour
{
    public StartingScreen StartScreen;
    public void Setup()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void AgainButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");

    }

}
