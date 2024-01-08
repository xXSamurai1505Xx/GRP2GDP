using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBin : MonoBehaviour
{

    public Transform playerTransform;
    public ButtonCheck buttonCheck;
    //public PlasticItem plasticItem;

    public ItemInformation itemInformation;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(playerTransform.position, transform.position) < 2f && buttonCheck.itemButtonClicked == true && itemInformation.itemInformation == "Metal")
        {
            Debug.Log("Metal Recycled");

            GameObject metal = GameObject.FindGameObjectWithTag("Metal");
            Destroy(metal);
            buttonCheck.itemButtonClicked = false;

        }
        else if (buttonCheck.itemButtonClicked == true && itemInformation.itemInformation != "Metal")
        {
            Debug.Log("Not Metal");
        }
    }
}
