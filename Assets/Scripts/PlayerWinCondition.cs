using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinCondition : MonoBehaviour
{
    
    //public ScoreManager scoreManager;

    public GameObject door;

    public RecycleGameObjective gameObjective;

    public Hints hints;

    // Update is called once per frame
    void Update()
    {

        if(gameObjective.currentScore == 7 && hints.showEscapePanel == 1)
        {
            hints.showEscapePanel = 0;
            hints.escapePanel();
        }

        if(gameObjective.currentScore == 7)
        {
            Debug.Log("Door removed");

            Destroy(door);
        }



    }
}
