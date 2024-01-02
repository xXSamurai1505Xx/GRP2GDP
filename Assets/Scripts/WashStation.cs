using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WashStation : MonoBehaviour
{
    public Transform washBasin;
    public GameObject cleanObject;
    public Button dirtyObjectButton;
    public Transform playerPosition;
    public ButtonCheck buttonCheck;

    private bool hasObjectBeenInstantiated = false;


    private void Update()
    {

        wash();
        
    }


    public void wash()
    {
        if (Vector3.Distance(washBasin.position, playerPosition.position) < 10f && buttonCheck.buttonClicked == true && !hasObjectBeenInstantiated )
        {
            Instantiate(cleanObject, washBasin.position, Quaternion.identity);

            buttonCheck.buttonClicked = false;

            hasObjectBeenInstantiated = true;

            Destroy(dirtyObjectButton.gameObject);

        }
    }


}
