using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperBin : MonoBehaviour
{
    public Transform playerTransform;
    public ButtonCheck buttonCheck;
    
    public RecycleGameObjective gameObjective;


   
    void Update()
    {
        if (Vector3.Distance(playerTransform.position, transform.position) < 2f && buttonCheck.paperButton == true)
        {
            Debug.Log("Paper Recycled");

            gameObjective.currentScore += 1;
            //scoreManager.AddPoints(10);
            GameObject paper = GameObject.FindGameObjectWithTag("Paper");
            Destroy(paper);
            buttonCheck.paperButton = false;

        }

    }
}
