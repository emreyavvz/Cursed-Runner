using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.5f;
    public AudioSource walk;
    public List<AudioClip> footsteps = new List<AudioClip>();
    //public bool allowToSpeak = false, onTalk = false;
    public GameObject talkingObject;
    public float footsteptimer;
    public GameObject fadelose;

    // Update is called once per frame

     void Start()
    {
        fadelose.GetComponent<CanvasGroup>().DOFade(0, 0.01f);
    }
    void Update()
    {
        footsteptimer-= Time.deltaTime;
        if (Input.GetKey(KeyCode.W) )
        {
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
            if (footsteptimer<=0)
            {
              walk.PlayOneShot(footsteps[Random.Range(0, footsteps.Count)]);
                footsteptimer = 1;
            }
        }
        else
        {

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(transform.up);
        }
        if (Input.GetKey(KeyCode.S) )
        {
            GetComponent<Rigidbody>().velocity = -transform.forward * speed;
        }        
        if (Input.GetKey(KeyCode.A))
        {            
            transform.Rotate(-transform.up);
        }
        if (Input.GetKey(KeyCode.E))
        {
            //allowToSpeak = false;
            //onTalk = true;
            //talkingObject.GetComponent<Speak>().SpeakFunction();
            //StartCoroutine(talkingObject.GetComponent<Speak>().SpeakRoutine());
        }
       
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Friendly")
    //    {
    //        print("Hi!");
    //        allowToSpeak = true;
    //        talkingObject = other.gameObject;
    //    }
    //    else if (other.tag == "Untagged")
    //    {
    //        print("No hi to you!");
    //    }
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Friendly")
    //    {
    //        print("Collision teması!");
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Friendly")
    //    {
    //        allowToSpeak = false;
    //        talkingObject = null;
    //    }
    //}
}
