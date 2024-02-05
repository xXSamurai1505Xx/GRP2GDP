using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticBin : MonoBehaviour
{

    public Transform playerTransform;
    public ButtonCheck buttonCheck;
    //public PlasticItem plasticItem;

    public ItemInformation itemInformation;
    //public ScoreManager scoreManager;
    public RecycleGameObjective gameObjective;
    
    public Hints hints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(playerTransform.position, transform.position) < 2f && buttonCheck.plasticButton == true && itemInformation.itemInformation == "Plastic")
        {
            Debug.Log("Plastic Recycled");

            gameObjective.currentScore += 1;
            //scoreManager.AddPoints(10);
            GameObject plastic = GameObject.FindGameObjectWithTag("Plastic");
            Destroy(plastic);
            buttonCheck.plasticButton = false;

        }
        else if (Vector3.Distance(playerTransform.position, transform.position) < 2f
            && buttonCheck.plasticButton == false
            && (buttonCheck.bannanaButton == true || buttonCheck.glassButton == true || buttonCheck.metalButton == true || buttonCheck.trashbagButton == true || buttonCheck.paperButton == true))
        {
            if (hints.hintNumber > 0)
            {
                hints.onClickHintPanelForBin();
                hints.hintNumber -= 1;
            }

            buttonCheck.bannanaButton = false;
            buttonCheck.glassButton = false;
            buttonCheck.metalButton = false;
            buttonCheck.trashbagButton = false;
            buttonCheck.paperButton = false;
            Debug.Log("Wrong Bin, Not this");
        }
    }



}
