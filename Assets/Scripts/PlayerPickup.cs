using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public bool pickup;


    // Update is called once per frame
    void Update()
    {
        if (pickup)
        {
            Destroy(GameObject.FindWithTag("Item"));
            pickup = false;
        }
    }


    public void PickupButtonUp()
    {
        pickup = true;
    }

    public void PickupButtonDown()
    {
        pickup = false; 
    }

}
