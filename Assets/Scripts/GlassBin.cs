using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBin : MonoBehaviour
{
    public Transform playerTransform;
    public ButtonCheck buttonCheck;
    //public PlasticItem plasticItem;

    //public ItemInformation itemInformation;
    //public ScoreManager scoreManager;
    public RecycleGameObjective gameObjective;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(playerTransform.position, transform.position) < 2f && buttonCheck.glassButton == true)
        {
            Debug.Log("Glass Bottle Recycled");

            //gameObjective.currentScore += 1;
            //scoreManager.AddPoints(10);
            GameObject glass = GameObject.FindGameObjectWithTag("Glass");
            Destroy(glass);
            buttonCheck.glassButton = false;

        }
        
    }
}
