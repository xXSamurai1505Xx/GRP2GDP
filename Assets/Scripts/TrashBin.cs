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
        else if (Vector3.Distance(playerTransform.position, transform.position) < 5.5f && (buttonCheck.metalButton == true || buttonCheck.plasticButton))
        {
            //scoreManager.AddPoints(-5);
            Debug.Log("Not Bannana Trash");
            buttonCheck.metalButton = false;
            buttonCheck.plasticButton = false;
        }
    }

}
