using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashController : MonoBehaviour
{
    public Transform washBasin;
    public Transform player; // Reference to the player
    public GameObject cleanObject;

    public void washObject()
    {
        if (player == null)
        {
            Debug.LogError("Player reference not set!");
            return;
        }

        Debug.Log("clicked");

        float distanceToPlayer = Vector3.Distance(player.position, washBasin.position);

        if (distanceToPlayer < 10f)
        {
            Debug.Log("success");

            GameObject cleanInstance = Instantiate(cleanObject, washBasin.position, Quaternion.identity);
        }
    }
}
