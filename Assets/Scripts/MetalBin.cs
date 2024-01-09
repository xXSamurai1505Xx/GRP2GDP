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
        else if (Vector3.Distance(playerTransform.position, transform.position) < 2f && buttonCheck.plasticButton == true)
        {
            //scoreManager.AddPoints(-5);
            Debug.Log("Not Metal");
            buttonCheck.plasticButton = false;

        }
    }
}
