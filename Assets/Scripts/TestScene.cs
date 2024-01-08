using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScene : MonoBehaviour
{
    public GameObject scene;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            scene.SetActive(true);
        }    
    }
}
