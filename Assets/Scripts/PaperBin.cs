using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperBin : MonoBehaviour
{
    public Transform playerTransform;
    public ButtonCheck buttonCheck;
    
    public RecycleGameObjective gameObjective;

    public Hints hints;

    void Update()
    {
        if (Vector3.Distance(playerTransform.position, transform.position) < 2f && buttonCheck.paperButton == true)
        {
            Debug.Log("Paper Recycled");

            gameObjective.currentScore += 1;
            GameObject paper = GameObject.FindGameObjectWithTag("Paper");
            Destroy(paper);
            buttonCheck.paperButton = false;
        }
        else if (Vector3.Distance(playerTransform.position, transform.position) < 2f
            && buttonCheck.paperButton == false
            && (buttonCheck.bannanaButton == true || buttonCheck.glassButton == true || buttonCheck.plasticButton == true || buttonCheck.trashbagButton == true || buttonCheck.metalButton == true))
        {

            if (hints.hintNumber > 0)
            {
                hints.onClickHintPanelForBin();
                hints.hintNumber -= 1;
            }

            buttonCheck.bannanaButton = false;
            buttonCheck.glassButton = false;
            buttonCheck.plasticButton = false;
            buttonCheck.trashbagButton = false;
            buttonCheck.metalButton = false;
            Debug.Log("Wrong Bin, Not this");
        }

    }
}
