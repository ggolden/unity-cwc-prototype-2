using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;

    // set to the game object that the player uses as a boundary
    // the player's collider will stay within the left and right (x) bounds of the boundary
    public GameObject boundary;

    private float nRange, pRange;

    void Start()
    {
        var renderer = boundary.GetComponent<MeshRenderer>();
        var xRange = renderer.bounds.size.x / 2;

        var collider = GetComponent<Collider>();
        var halfWidth = collider.bounds.size.x / 2;

        nRange = -xRange + halfWidth;
        pRange = xRange - halfWidth;

        Debug.Log(name + " - collider: " + collider.bounds.size);
        Debug.Log(boundary.name + " - renderer: " + renderer.bounds.size);
        Debug.Log("nRange: " + nRange + " - pRange: " + pRange);
    }

    private void positionFromControls()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);
    }

    private void constrainToBounds()
    {
        if (transform.position.x < nRange)
        {
            transform.position = new Vector3(nRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > pRange)
        {
            transform.position = new Vector3(pRange, transform.position.y, transform.position.z);
        }
    }

    void Update()
    {
        positionFromControls();
        constrainToBounds();
    }
}
