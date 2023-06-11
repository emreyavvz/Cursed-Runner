using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerInfo : MonoBehaviour
{
    public int siringa;
    public TMP_Text hptext;
    public Slider siringaSlider;
    public Slider hizSlider;
    float siringaTimeLeft = 10.0f;
    float siringaTimeLeft2 = 10.0f;
    public Boolean isSiringaEffect = false;
    public Boolean isSiringaEffect2 = false;
    public Boolean isSiringaRun = false;
    public Boolean darkness = false;
    public float sliderValue;
    public bool siringaMaxer = false;
    public bool siringaMaxer2 = false;
    public bool siringaMaxSpam = true;
    public bool siringaMaxSpam2 = true;
    public bool medic;
    public bool energy;
    public bool health;
    public bool NPC1;
    public bool Hizalabilir = false;
    public bool hizactive = false;
    public Slider slider;
    public Slider shoeSlider;
    public Movement movement;
    public GameObject shoe;
    public GameObject gameOverPanel;
    public GameObject credit;
    public GameObject textInfo;

    public AudioSource reward;
    public List<AudioClip> rewards = new List<AudioClip>();
    // Start is called before the first frame update
    void Start()
    {
        reward.PlayOneShot(rewards[2]);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        sliderValue = siringaSlider.value;

        if (Input.GetKeyDown(KeyCode.R) && siringaMaxSpam && medic)
        {
            siringaUse(1);

            siringaMaxer = true;
            if (Hizalabilir)
            {
                shoe.SetActive(false);
                siringaMaxer2 = true;
                StartCoroutine(Hiz());
                Hizalabilir = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && energy)
        {
            siringaUseToEnergy(3);
            

            //reward.PlayOneShot(rewards[1]);
        }

        if (Input.GetKeyDown(KeyCode.R) && NPC1)
        {
            if (this.siringa >= 21)
            {
                credit.SetActive(true);
            }
            //reward.PlayOneShot(rewards[1]);
        }

        if (Input.GetKeyDown(KeyCode.R) && health)
        {
            siringaUseToHealth(7);
            
        }
        if (slider.value <= 0f)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (isSiringaEffect)
        {
            if (siringaMaxer == true)
            {
                siringaSlider.value = 10;
                siringaMaxer = false;
                siringaMaxSpam = false;
            }
            if (siringaSlider.value >= 0f)
            {
                siringaSlider.value -= 1 *Time.deltaTime;
                //reward.PlayOneShot(rewards[3]);
            }
            siringaTimeLeft -= Time.deltaTime;
            
            if (siringaTimeLeft < 0)
            {
                isSiringaEffect = false;
                siringaTimeLeft = 10.0f;
                siringaMaxSpam = true;
            }
        }
        else if (darkness)
        {
            slider.value -= Time.deltaTime * 5;
        }
        else
        {
            siringaSlider.value = 0;
        }


        if (isSiringaEffect2)
        {
            if (siringaMaxer2 == true)
            {
                shoeSlider.value = 10;
                siringaMaxer2 = false;
                siringaMaxSpam2 = false;
                Debug.Log("HEU");
            }
            if (shoeSlider.value >= 0f)
            {
                shoeSlider.value -= 1 * Time.deltaTime;
            }
            siringaTimeLeft2 -= Time.deltaTime;

            if (siringaTimeLeft < 0)
            {
                isSiringaEffect2 = false;
                siringaTimeLeft2 = 10.0f;
                siringaMaxSpam2 = true;
            }
        }
        else
        {
            shoeSlider.value = 0;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Medic"))
        {
            textInfo.GetComponent<TextMeshProUGUI>().text = "R tuþu ile ayakkabýyý ve 1 ilaç karþýlýðýnda panzehiri aktif edebilirsin";
            textInfo.SetActive(true);
            medic = true;
        }
        if (other.CompareTag("Energy"))
        {
            textInfo.GetComponent<TextMeshProUGUI>().text = "R tuþu ile 3 ilaç karþýlýðýnda hýzlý koþmaný saðlayacak ayakkabýyý alabilirsin";
            textInfo.SetActive(true);
            energy = true;
        }
        if (other.CompareTag("Health"))
        {
            textInfo.GetComponent<TextMeshProUGUI>().text = "R tuþu ile 7 ilaç karþýlýðýnda saðlýðýný yenile";
            textInfo.SetActive(true);
            health = true;
        }
        if (other.CompareTag("NPC1"))
        {
            NPC1 = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Medic"))
        {
            textInfo.SetActive(false);
            medic = false;
        }
        if (other.CompareTag("Energy"))
        {
            textInfo.SetActive(false);
            energy = false;
        }
        if (other.CompareTag("Health"))
        {
            textInfo.SetActive(false);
            health = false;
        }
        if (other.CompareTag("NPC1"))
        {
            NPC1 = false;
        }

    }

    
    public void siringaUpdate(int newValue)
    {
        this.siringa += newValue;
        hptext.text = siringa.ToString();

    }

    public void siringaUse(int newValue)
    {
        if (this.siringa >= 1)
        {
            this.siringa -= newValue;
            hptext.text = siringa.ToString();
            isSiringaEffect = true;
            reward.PlayOneShot(rewards[0]);
        }
    }

    public void siringaUseToEnergy(int newValue)
    {
        if (this.siringa >= 3)
        {
            shoe.SetActive(true);
            //reward.PlayOneShot(rewards[1]);
            this.siringa -= newValue;
            hptext.text = siringa.ToString();
            reward.PlayOneShot(rewards[1]);
            Hizalabilir = true;
            isSiringaEffect2 = true;
        }
    }

    public void siringaUseToHealth(int newValue)
    {
        if (this.siringa >= 7)
        {
            this.siringa -= newValue;
            hptext.text = siringa.ToString();
            reward.PlayOneShot(rewards[0]);
            slider.value = 100;
            //isSiringaEffect = true;
        }
    }

    IEnumerator Hiz()
    {
        movement.speed2 *= 1.5f;
        yield return new WaitForSeconds(10f);
        movement.speed2 /= 1.5f;
    }

}
