using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinCondition : MonoBehaviour
{
    
    //public ScoreManager scoreManager;

    public GameObject door;

    public RecycleGameObjective gameObjective;

    // Update is called once per frame
    void Update()
    {
        

        if(gameObjective.currentScore == 10)
        {
            Debug.Log("Door removed");

            Destroy(door);
        }



    }
}
