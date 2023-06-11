using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.Impl;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    public AudioSource sound;
    public List<AudioClip> monsterear = new List<AudioClip>();
    public float monstersound;
    public Transform player;
    public GameObject playerOBJ;
    public GameObject playerLose;
  


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        monstersound-=Time.deltaTime;
        if (monstersound<=0)
        {
            sound.PlayOneShot(monsterear[Random.Range(0, monsterear.Count)]);
            monstersound = 15;

        }
        enemy.SetDestination(player.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            StartCoroutine(sequence());
            
        }
    }

    IEnumerator sequence()
    {

        playerOBJ.transform.DORotate(new Vector3(0, 450, 0), 1f);
        yield return new WaitForSeconds(.4f);
        GetComponent<Animator>().Play("sword attack");
        yield return new WaitForSeconds(1f);
        playerLose.SetActive(true);
        playerLose.GetComponent<CanvasGroup>().DOFade(1, 1f);
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;

    }


}
