using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicSceneManager : MonoBehaviour
{

    public GameObject gameOverScreen;

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
}
