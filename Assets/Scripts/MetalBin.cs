using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBin : MonoBehaviour
{

    public Transform playerTransform;
    public ButtonCheck buttonCheck;
    //public PlasticItem plasticItem;

    public ItemInformation itemInformation;

    public RecycleGameObjective gameObjective;

    public Hints hints;

    //public ScoreManager scoreManager;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(playerTransform.position, transform.position) < 2f && buttonCheck.metalButton == true && itemInformation.itemInformation == "Metal")
        {
            Debug.Log("Metal Recycled");

            gameObjective.currentScore += 1;
            //scoreManager.AddPoints(10);
            GameObject metal = GameObject.FindGameObjectWithTag("Metal");
            Destroy(metal);
            buttonCheck.metalButton = false;

        }
        else if (Vector3.Distance(playerTransform.position, transform.position) < 2f
            && buttonCheck.metalButton == false
            && (buttonCheck.bannanaButton == true || buttonCheck.glassButton == true || buttonCheck.plasticButton == true || buttonCheck.trashbagButton == true || buttonCheck.paperButton == true))
        {

            if(hints.hintNumber > 0)
            {
                hints.onClickHintPanelForBin();
                hints.hintNumber -= 1;
            }

            buttonCheck.bannanaButton = false;
            buttonCheck.glassButton = false;
            buttonCheck.plasticButton = false;
            buttonCheck.trashbagButton = false;
            buttonCheck.paperButton = false;
            Debug.Log("Wrong Bin, Not this");
        }
    }
}
