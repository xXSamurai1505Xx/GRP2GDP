using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public bool pickup;

    [HideInInspector]
    public int itemNumber = 0;



    private void Start()
    {
        pickup = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item" && pickup == true)
        {
            Destroy(collision.gameObject);
            itemNumber += 1;

        }
    }

    

}
