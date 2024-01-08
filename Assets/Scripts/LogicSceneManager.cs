using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicSceneManager : MonoBehaviour
{

    public GameObject gameOverScreen;

    public void restart()
    {
        gameOverScreen.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void startGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
