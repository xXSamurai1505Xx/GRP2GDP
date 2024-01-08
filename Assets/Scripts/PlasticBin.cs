using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticBin : MonoBehaviour
{

    public Transform playerTransform;
    public ButtonCheck buttonCheck;
    //public PlasticItem plasticItem;

    public ItemInformation itemInformation;
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(playerTransform.position, transform.position) < 2f && buttonCheck.itemButtonClicked == false && buttonCheck.plasticButton == true && itemInformation.itemInformation == "Plastic")
        {
            Debug.Log("Plastic Recycled");

            scoreManager.AddPoints(10);
            GameObject plastic = GameObject.FindGameObjectWithTag("Plastic");
            Destroy(plastic);
            buttonCheck.plasticButton = false;

        }
        else if(Vector3.Distance(playerTransform.position, transform.position) < 2f && buttonCheck.metalButton == true )
        {
            scoreManager.AddPoints(-5);
            Debug.Log("Not Plastic");
            buttonCheck.metalButton = false;
        }
    }



}
