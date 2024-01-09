using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEscape : MonoBehaviour
{

    public LogicSceneManager sceneManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sceneManager.gameComplete();
        }
    }
}
