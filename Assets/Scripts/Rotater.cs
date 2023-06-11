using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{

    public float rotationSpeed = 10f; // Speed of rotation in degrees per second
    public KeyCode rotationKey = KeyCode.R;

    public KeyCode rotationKeyTwo = KeyCode.T; // Key to press to start rotation

    private bool isRotating = false; // Flag to track if rotation is currently happening

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(rotationKey))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(rotationKeyTwo))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        if (isRotating)
        { // Check if rotation is currently happening
          // Rotate the object around its y-axis
        }
    }


}
