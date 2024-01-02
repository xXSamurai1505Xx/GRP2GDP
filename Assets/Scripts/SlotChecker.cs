using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotChecker : MonoBehaviour
{

    private PlayerInventory inventory;

    public int i;


    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }


    // Update is called once per frame
    private void Update()
    {

        if(transform.childCount <= 0)
        {
            inventory.isFull[i] = false; 
        }
        
    }
}
