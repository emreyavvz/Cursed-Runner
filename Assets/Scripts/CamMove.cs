using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Sensitivity of mouse movement
    public Transform playerBody; // Reference to player's body (used for rotating player)

    float xRotation = 0f; // Current rotation around x-axis (up and down)
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LookAngle());
    }

    // Update is called once per frame
    void Update()
    {
        MouseLook();
    }

    public void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; // Get horizontal mouse movement
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; // Get vertical mouse movement

        xRotation -= mouseY; // Update current x-axis rotation
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp x-axis rotation to prevent player from rotating too far

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Rotate camera up and down based on current x-axis rotation
        playerBody.Rotate(Vector3.up * mouseX); // Rotate player left and right based on horizontal mouse movement
    }

    IEnumerator LookAngle()
    {
        yield return new WaitForSeconds(.6f);
        xRotation = 0f;
    }

}
