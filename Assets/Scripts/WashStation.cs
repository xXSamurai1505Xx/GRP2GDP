using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WashStation : MonoBehaviour
{
    public Transform spawnArea;
    public GameObject cleanObject;

    //public GameObject dirtyObjectButton;
    public string dirtyObjectButtonTag = "DirtyObjectButton";



    public Transform playerPosition;
    public ButtonCheck buttonCheck;

    public bool hasObjectBeenInstantiated = false;



    

    private void Update()
    {

        wash();
        
    }


   



    public void wash()
    {
        if (Vector3.Distance(spawnArea.position, playerPosition.position) < 4f && buttonCheck.buttonClicked == true && !hasObjectBeenInstantiated )
        {
            Instantiate(cleanObject, spawnArea.position, Quaternion.identity);

            buttonCheck.buttonClicked = false;

            hasObjectBeenInstantiated = true;

            GameObject[] dirtyButtons = GameObject.FindGameObjectsWithTag(dirtyObjectButtonTag);

            // Destroy all found buttons (you can adjust this logic based on your needs)
            foreach (var dirtyButton in dirtyButtons)
            {
                Debug.Log("Destroying dirty button...");
                Destroy(dirtyButton);
            }



        }
    }


}
