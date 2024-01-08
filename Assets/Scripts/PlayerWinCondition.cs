using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinCondition : MonoBehaviour
{
    public LogicSceneManager sceneManager;
    public ScoreManager scoreManager;

    // Update is called once per frame
    void Update()
    {
        if(scoreManager.playerScore >= 20)
        {
            sceneManager.gameComplete();
        }
    }
}
