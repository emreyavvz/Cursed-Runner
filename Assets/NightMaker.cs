using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightMaker : MonoBehaviour
{
    public Animator animator;
    public bool firstEnter = true;
    public bool secondEnter = false;
    public PlayerInfo playerInfo;
    public AudioSource reward;
    public AudioSource reward2;
    public List<AudioClip> rewards = new List<AudioClip>();
    public List<GameObject> objects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (firstEnter)
            {
                animator.Play("LightDownAnim");
                firstEnter = false;
                secondEnter = true;
                playerInfo.darkness = true;
                reward2.Stop();
                reward.PlayOneShot(rewards[0]);
                reward.PlayOneShot(rewards[2]);
            }
            else if (secondEnter)
            {
                animator.Play("LightUpAnim");
                firstEnter = true;
                secondEnter = false;
                playerInfo.darkness = false;
                reward2.PlayOneShot(rewards[1]);
                reward.Stop();

                foreach (var item in objects)
                {
                    if(item.activeInHierarchy == false)
                    {
                        item.SetActive(true);
                        break;
                    }
                }

            }
        }
    }
}
