using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject WinCanvas;
    public GameObject Player;
    public TMP_Text Text;
  
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
            if (Text.text=="6")
            {
                WinCanvas.SetActive(true);
                Player.GetComponent<PlayerController>().enabled = false;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                
            }
            
        }
    }
}
