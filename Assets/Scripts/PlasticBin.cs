using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticBin : MonoBehaviour
{
    public ButtonCheck buttonCheck;


    public void onPointDown()
    {
        if (buttonCheck.plasticButton == true)
        {
            Debug.Log("Plastic works");
            GameObject plasticButton = GameObject.FindWithTag("Plastic");
            Destroy(plasticButton);
        }
    }
    


}
