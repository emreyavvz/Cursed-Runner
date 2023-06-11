using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.XR;

public class Collectable : MonoBehaviour
{
    public Animator animator;
    public GameObject hand;
    public AudioSource reward;
    public List<AudioClip> rewards = new List<AudioClip>();
    // Start is called before the first frame update
    void Start()
    {
        reward = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Sabir());
            Debug.Log("SA");
            //hand.GetComponent<Animator>().SetBool("bjj", true);
            //animator.SetBool("bjj", true);
            other.gameObject.GetComponent<PlayerInfo>().siringaUpdate(1);
            //animator.SetBool("bjj", false);
            reward.PlayOneShot(rewards[0]);
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(this.gameObject, 1f);
        }

    }

    IEnumerator Sabir()
    {
        //hand.GetComponent<Animator>().SetBool("bjj",true);
        animator.SetBool("bjj", true);
        yield return new WaitForSeconds(.3f);
        animator.SetBool("bjj", false);
        //hand.GetComponent<Animator>().SetBool("bjj", false);
    }
}
