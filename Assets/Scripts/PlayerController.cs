using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;

    // set to the game object that the player uses as a boundary
    // the player's collider will stay within the left and right (x) bounds of the boundary
    public GameObject boundary;

    private float nRange = -10.0f;
    private float pRange = 10.0f;

    private void init()
    {
        var renderer = boundary.GetComponent<MeshRenderer>();
        var xRange = renderer.bounds.size.x / 2;

        var collider = GetComponent<Collider>();
        var halfWidth = collider.bounds.size.x / 2;

        nRange = -xRange + halfWidth;
        pRange = xRange - halfWidth;

        // TODO: currently only uses the x bounds, not the position - center might help

        Debug.Log(name + " - collider: " + collider.bounds.size + " - center: " + collider.bounds.center);
        Debug.Log(boundary.name + " - renderer: " + renderer.bounds.size + " - center: " + renderer.bounds.center);
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

    void Start()
    {
        // init();
    }

    void Update()
    {
        positionFromControls();
        constrainToBounds();
    }
}
