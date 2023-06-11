using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement in units per second
    public float mouseSensitivity = 100f; // Sensitivity of mouse movement
    public Transform playerBody; // Reference to player's body (used for rotating player)
    public float speed = 100f;
    public float speed2 = 3.5f;
    public float footsteptimer;
    public AudioSource walk;
    public List<AudioClip> footsteps = new List<AudioClip>();

    public GameObject Text;
    public GameObject Text1;

    float xRotation = 0f; // Current rotation around x-axis (up and down)
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        //RigidMove();
        //MovementFunc();
        LastMovement();
        //moveRigid();
        //MouseLook();

        
        footsteptimer -= Time.deltaTime;
    }

    //private void FixedUpdate()
    //{
    //    float horizontalInput = Input.GetAxis("Horizontal");
    //    float verticalInput = Input.GetAxis("Vertical");

    //    Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed;
    //    rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    //}

    public void LastMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            walk.enabled = true;
            GetComponent<Rigidbody>().velocity = transform.forward * speed2;

            //if (footsteptimer <= 0)
            //{
            //    if (GetComponent<Rigidbody>().velocity != Vector3.zero)
            //    {
                    
            //        footsteptimer = 1;
            //    }
            //}
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            walk.enabled = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //transform.Rotate(transform.up);
            GetComponent<Rigidbody>().velocity = transform.right * speed2;
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().velocity = -transform.forward * speed2;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //transform.Rotate(-transform.up);
            GetComponent<Rigidbody>().velocity = -transform.right * speed2;
        }
    }
    public void MovementFunc()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Get horizontal input (A and D keys or left/right arrow keys)
        float verticalInput = Input.GetAxis("Vertical"); // Get vertical input (W and S keys or up/down arrow keys)

        // Calculate movement vector based on input and move speed
        Vector3 movement = transform.right * horizontalInput * speed * Time.deltaTime + transform.forward * verticalInput * speed * Time.deltaTime;

        //new Vector3(-verticalInput, 0f, horizontalInput) * moveSpeed * Time.deltaTime;

        // Apply movement to player's position
        transform.position += movement;
    }

    public void RigidMove()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); 
        float verticalInput = Input.GetAxis("Vertical"); 

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed;
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

    public void moveRigid()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Get horizontal input (A and D keys or left/right arrow keys)
        float verticalInput = Input.GetAxis("Vertical"); // Get vertical input (W and S keys or up/down arrow keys)

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed; // Calculate movement vector based on input and move speed

        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z); // Apply horizontal movement to Rigidbody component
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("NPC1"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(TextActivator());
            }
        }
    }

    IEnumerator TextActivator()
    {
        Text.SetActive(true);
        //Debug.Log(Text.GetComponent<TextMeshProUGUI>().text);
        yield return new WaitForSeconds(10f);
        Text.GetComponent<TextMeshProUGUI>().text = "Juanita ilaçlarý kullanmaný saðlayacak.";
        yield return new WaitForSeconds(3f);
        Text.GetComponent<TextMeshProUGUI>().text = "Wrathchild 7 ilaç karþýlýðýnda saðlýðýný yeneleyecek.";
        yield return new WaitForSeconds(3f);
        Text.GetComponent<TextMeshProUGUI>().text = "Senjutsu ise 3 ilaç karþýlýðýnda hýzlý koþmaný saðlayacak bir ayakkabý verecek.";
        yield return new WaitForSeconds(3f);
        Text.GetComponent<TextMeshProUGUI>().text = "Hepimizin hayatý için ilaçlarý lütfen diðer taraftan getir...";
        yield return new WaitForSeconds(3f);
        Text.SetActive(false);
        Text1.SetActive(true);
        Text.GetComponent<TextMeshProUGUI>().text = "Iienomdrna... Oðlum diðer tarafta öldü diðer herkes gibi... Biz ordaki hastalýktan kaçarken o kaçamadý... Elimizdeki ilaçlar da yeterli deðil. Yakýnda ilaçlarýmýz bitecek ve diðer taraftan gidip alabileceðine güvendiðim tek insan sensin. ";
    }

}
