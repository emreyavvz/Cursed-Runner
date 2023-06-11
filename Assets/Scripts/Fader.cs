using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using System;

public class Fader : MonoBehaviour
{
    public TMP_Text mytext;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            GetComponent<SpriteRenderer>().DOFade(0, 1);
            int myint = Convert.ToInt32(mytext.text) ;
            myint += 1;
            mytext.text = myint.ToString();
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
