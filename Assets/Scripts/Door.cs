using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    public GameObject door_1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            door_1.transform.DOMove(door_1.transform.position + new Vector3(0, -10, 0), 6f);

            //transform.DOMove(transform.position + new Vector3(-50,0,0),1f);
            Debug.Log("AAAA");
            
        }
    }
}
