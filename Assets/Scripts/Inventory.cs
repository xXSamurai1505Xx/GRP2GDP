using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ItemPickup itemPickup;

    private void Start()
    {
        itemPickup = GetComponent<ItemPickup>();
    }


    private void Update()
    {
        if(itemPickup.itemNumber == 3)
        {
            Debug.Log("Item Storage is full");
            itemPickup.pickup = false;
        }
    }




}
