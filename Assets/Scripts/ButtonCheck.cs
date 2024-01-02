using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCheck : MonoBehaviour
{
    public bool buttonClicked = false;




    public void activateWash()
    {
        buttonClicked = true;



    }

    public void disactivateWash()
    {
        buttonClicked = false;
        


    }

}
