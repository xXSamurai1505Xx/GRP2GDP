using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCheck : MonoBehaviour
{
    public bool buttonClicked = false;
    public bool plasticButton = false;

    

    public void activateWash()
    {
        buttonClicked = true;

        
        
    }

    public void disactivateWash()
    {
        buttonClicked = !buttonClicked;


    }


    public void upPlastic()
    {
        plasticButton = false;
    }


    public void downPlastic()
    {
        plasticButton = true;
    }

}
