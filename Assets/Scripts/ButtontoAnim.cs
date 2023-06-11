using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtontoAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)) 
        {
            GetComponent<Animator>().Play("Petting Animal");
        }
    }
}
