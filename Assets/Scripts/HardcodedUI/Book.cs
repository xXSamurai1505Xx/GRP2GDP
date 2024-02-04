using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public GameObject BookUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenBook()
    {
        BookUI.SetActive(true);
    }
    public void CloseBook()
    {
        BookUI.SetActive(false);
    }
}
