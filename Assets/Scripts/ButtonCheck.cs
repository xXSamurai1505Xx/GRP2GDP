using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCheck : MonoBehaviour
{
    public bool buttonClicked = false;
    public bool itemButtonClicked = false;

    public bool plasticButton = false; 
    public bool metalButton = false;



    public void activateWash()
    {
        buttonClicked = true;

    }

    public void disactivateWash()
    {
        buttonClicked = false;
        


    }


    public void checkItemUp()
    {
        itemButtonClicked = false;
    }

    public void checkItemDown()
    {
        itemButtonClicked= true;
    }


    public void plasticItemUp()
    {
        plasticButton = false;
    }

    public void plasticItemDown()
    {
        plasticButton = true;
    }


    public void metalItemUp() 
    {
        metalButton = false;
    }

    public void metalItemDown()
    {
        metalButton = true;
    }

}
