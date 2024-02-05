using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Bson;
using UnityEngine;

public class Hints : MonoBehaviour
{
    public int hintNumber;
    public int showEscapePanel;

    public GameObject hintPanelForBin;
    public GameObject hintPanelForDirtyBottle;
    public GameObject hintPanelToEscape;

    private void Start()
    {
        hintNumber = 5;
        showEscapePanel = 1;
    }

    public void onClickHintPanelForBin()
    {
        hintPanelForBin.SetActive(true);
    }

    public void closeHintPanelForBin()
    {
        hintPanelForBin.SetActive(false);
    }

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

}
