using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticBin : MonoBehaviour
{

    public Transform playerTransform;
    public ButtonCheck buttonCheck;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(playerTransform.position, transform.position) < 4f && buttonCheck.plasticButton == true)
        {
            Debug.Log("Plastic Recycled");

            GameObject plastic = GameObject.FindGameObjectWithTag("Plastic");
            Destroy(plastic);

            buttonCheck.plasticButton = false;




        }
    }



}
