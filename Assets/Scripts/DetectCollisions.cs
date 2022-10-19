using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(gameObject.name + " - collided with: " + other.name);

        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
