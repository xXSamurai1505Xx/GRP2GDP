using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicSceneManager : MonoBehaviour
{

    public GameObject gameOverScreen;
    public GameObject gameCompleteScreen;

    public void restart()
    {
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }

    public void startGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void gameComplete()
    {
        gameCompleteScreen.SetActive(true);
    }

    public void homeMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }

}
