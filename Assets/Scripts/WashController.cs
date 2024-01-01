using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashController : MonoBehaviour
{
    public Transform washBasin;
    public GameObject cleanObject;

    public void washObject()
    {
        if (Vector3.Distance(transform.position, washBasin.position) < 0.1f)
        {
            GameObject cleanInstance = Instantiate(cleanObject, washBasin.position, Quaternion.identity);
        }
    }
}
