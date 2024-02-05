using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Bson;
using UnityEngine;
using TMPro;

public class Hints : MonoBehaviour
{
    public int hintNumber;
    public int showEscapePanel;
    public int hintBookCount;

    public GameObject hintPanelForBin;
    public GameObject hintPanelForDirtyBottle;
    public GameObject hintPanelToEscape;
    public GameObject hintBook;

    public GameObject hintButton;

    public TMP_Text hintCountText;

    private void Start()
    {
        //hintNumber = 5;
        showEscapePanel = 1;
        hintBookCount = 3;

        updateHintCount();

    }

    private void Update()
    {
        if(hintBookCount <= 0)
        {
            hintButton.SetActive(false);    
        }



    }


    public void updateHintCount()
    {
        
        hintCountText.text = "Hints Left: " + hintBookCount;
    }


    public void onClickHintPanelForBin()
    {
        StartCoroutine(ShowPanelForBin());
    }

    private IEnumerator ShowPanelForBin()
    {
        hintPanelForBin.SetActive(true);

        // Wait for 1 second
        yield return new WaitForSeconds(1f);

        // Set the panel back to inactive after 1 second
        hintPanelForBin.SetActive(false);
    }

    //public void closeHintPanelForBin()
    //{
        //hintPanelForBin.SetActive(false);
    //}

    public void panelForDirtyBottle()
    {
        hintPanelForDirtyBottle.SetActive(true);
    }

    public void closeHintPanelForDirtyBottle()
    {
        hintPanelForDirtyBottle.SetActive(false);
    }

    public void escapePanel()
    {
        hintPanelToEscape.SetActive(true);
    }

    public void closeEscapePanel()
    {
        hintPanelToEscape.SetActive(false);
    }

    public void hintBookPanel()
    {
        hintBookCount --;
        updateHintCount();
        hintBook.SetActive(true);
    }

    public void closeHintBookPanel()
    {
        hintBook.SetActive(false);
    }


}
