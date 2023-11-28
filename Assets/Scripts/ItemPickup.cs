using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public bool pickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && pickup == true)
        {
            Destroy(gameObject);
            //pickup = false;
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
