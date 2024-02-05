using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hints : MonoBehaviour
{
    public int hintNumber;

    public GameObject hintPanelForBin;
    public GameObject hintPanelForDirtyBottle;

    private void Start()
    {
        hintNumber = 5;
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

}
