using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public bool pickup;
    public bool pickupButtonDown;

    // Update is called once per frame
    void Update()
    {
        if(pickupButtonDown)
        {
            pickup = true;
        }
    }


    public void PickupButtonUp()
    {
        pickupButtonDown = true;
    }

    public void PickupButtonDown()
    {
        pickupButtonDown = false; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (pickup && collision.tag == "Item")
        {
            Destroy(GameObject.FindWithTag("Item"));
            pickup = false;
        }
    }
}
