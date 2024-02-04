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
    // Start is called before the first frame update
    public void CloseIntroduction()
    {
        IntroductionText.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void GoToNextText()
    {
        Text1.SetActive(false);
        Text2.SetActive(true);
        NextButton.SetActive(false);
        CloseButton.SetActive(true);
    }
}
