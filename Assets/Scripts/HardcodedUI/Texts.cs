using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texts : MonoBehaviour
{
    public GameObject IntroductionText;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject NextButton;
    public GameObject CloseButton;
    public GameObject Book;
    // Start is called before the first frame update
    public void CloseIntroduction()
    {
        IntroductionText.SetActive(false);
        Book.SetActive(true);
    }
    public void GoToNextText()
    {
        Text1.SetActive(false);
        Text2.SetActive(true);
        NextButton.SetActive(false);
        CloseButton.SetActive(true);
    }
    public void CloseBook()
    {
        Book.SetActive(false);
    }
}
