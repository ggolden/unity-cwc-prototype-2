using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(gameObject.name + " - collided with: " + other.name);

        // don't collide with another object of the same type, to support food rapid fire
        if (!other.gameObject.name.Equals(gameObject.name))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
