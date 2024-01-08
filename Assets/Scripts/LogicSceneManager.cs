using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicSceneManager : MonoBehaviour
{

    public GameObject gameOverScreen;

    public void Restart()
    {
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void startGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
