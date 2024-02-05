using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
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
        if (Vector3.Distance(playerTransform.position, transform.position) < 5.5f && buttonCheck.bannanaButton == true)
        {
            Debug.Log("Bannana thrown away");

            //gameObjective.currentScore += 1;
            //scoreManager.AddPoints(10);
            GameObject bannana = GameObject.FindGameObjectWithTag("Bannana");
            Destroy(bannana);
            buttonCheck.bannanaButton = false;

        }
        else if (Vector3.Distance(playerTransform.position, transform.position) < 5.5f && buttonCheck.trashbagButton == true)
        {
            Debug.Log("Trash thrown away");

            //gameObjective.currentScore += 1;
            //scoreManager.AddPoints(10);
            GameObject trash = GameObject.FindGameObjectWithTag("Trash");
            Destroy(trash);
            buttonCheck.trashbagButton = false;

        }
        else if (Vector3.Distance(playerTransform.position, transform.position) < 5.5f
            
            && (buttonCheck.glassButton == true || buttonCheck.plasticButton == true || buttonCheck.metalButton == true || buttonCheck.paperButton == true))
        {
            hints.onClickHintPanelForBin();

            buttonCheck.glassButton = false;
            buttonCheck.plasticButton = false;
            buttonCheck.metalButton = false;
            buttonCheck.paperButton = false;
            Debug.Log("Are you sure this is trash");
        }

    }

}
