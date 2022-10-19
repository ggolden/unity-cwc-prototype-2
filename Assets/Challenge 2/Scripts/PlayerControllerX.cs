using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float delayAfterFire = 2.0f;

    public float fireAgainAfter = 0.0f;

    // Update is called once per frame
    void Update()
    {
        float now = Time.fixedTime;

        if (Input.GetKeyDown(KeyCode.Space) && (now > fireAgainAfter))
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

            fireAgainAfter = now + delayAfterFire;
        }
    }
}
