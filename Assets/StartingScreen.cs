using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartingScreen : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0f;
    }
    public void Setup()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void BeginButton()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

}
