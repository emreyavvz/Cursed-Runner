using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;
using TMPro;

public class OnTriggerDemonMove : MonoBehaviour
{
    public GameObject devil;
    public GameObject picture;
    public Transform playerObj;
    public TMP_Text PickNumber;
    bool triggered = false;
    float counter ;
    public GameObject Arrow;
    public GameObject Exit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (counter >= 3 && triggered)
        {
            //DevilRun();
            counter = 0;
        }

        counter += Time.deltaTime;
        if (PickNumber.text=="6")
        {
            StartCoroutine(FadeandActivator());
            Arrow.SetActive(true);
            Exit.transform.DOMove(Exit.transform.position + new Vector3(0, -5, 0),1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            //devil.transform.DOMove(playerObj.position, 3f);
            triggered = true;
            //StartCoroutine(FadeandActivator());
        }
    }

    public void DevilRun()
    {
        devil.transform.DOMove(playerObj.position, 3f).SetEase(Ease.Linear);
        devil.transform.DORotateQuaternion(playerObj.rotation, 3f);
    }

    IEnumerator FadeandActivator()
    {
        picture.GetComponent<SpriteRenderer>().DOFade(0, 1f);
        yield return new WaitForSeconds(.8f);
        devil.SetActive(true);
        yield return new WaitForSeconds(.2f);
        devil.GetComponent<NavMeshAgent>().enabled = true;
    }

    IEnumerator DevilFollow() 
    {

        devil.transform.DOMove(playerObj.position, 3f).SetEase(Ease.Linear);
        
        yield return new WaitForSeconds(3f);
        
    }
}
