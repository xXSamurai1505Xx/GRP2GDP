using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingStation : MonoBehaviour
{
    public Transform spawnArea;
    public GameObject cleanObject;

    //public GameObject dirtyObjectButton;
    public string dirtyObjectButtonTag = "DirtyObjectButton";



    public Transform playerPosition;
    public ButtonCheck buttonCheck;

    public bool hasObjectBeenInstantiated = false;

    public ScoreManager scoreManager;   

    private void Update()
    {

        wash();

    }






    public void wash()
    {
        if (Vector3.Distance(spawnArea.position, playerPosition.position) < 4f && buttonCheck.buttonClicked == true && !hasObjectBeenInstantiated)
        {
            Instantiate(cleanObject, spawnArea.position, Quaternion.identity);

            scoreManager.AddPoints(5);

            buttonCheck.buttonClicked = false;

            hasObjectBeenInstantiated = true;

            GameObject dirtyButton = GameObject.FindGameObjectWithTag(dirtyObjectButtonTag);

            // Destroy all found buttons (you can adjust this logic based on your needs)
            

            Debug.Log("Destroying dirty button...");
            Destroy(dirtyButton);

            hasObjectBeenInstantiated = false;

        }
    }
}
