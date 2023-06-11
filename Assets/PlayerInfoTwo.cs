using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerInfoTwo : MonoBehaviour
{
    public int siringa;
    public TMP_Text hptext;
    public Slider siringaSlider;
    float siringaTimeLeft = 10.0f;
    public Boolean isSiringaEffect = false;
    public Boolean darkness = false;
    public float sliderValue;
    public bool siringaMaxer = false;
    public bool siringaMaxSpam = true;
    public bool medic;
    public bool energy;
    public bool health;
    public bool Hizalabilir = false;
    public Slider slider;
    public Slider shoeSlider;
    public Movement movement;

    public AudioSource reward;
    public List<AudioClip> rewards = new List<AudioClip>();
    // Start is called before the first frame update
    void Start()
    {

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
                StartCoroutine(Hiz());
                Hizalabilir = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && energy)
        {
            siringaUseToEnergy(3);
            //reward.PlayOneShot(rewards[1]);
        }

        if (Input.GetKeyDown(KeyCode.R) && health)
        {
            siringaUseToHealth(7);

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
                siringaSlider.value -= 1 * Time.deltaTime;
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

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Medic"))
        {
            medic = true;
        }
        if (other.CompareTag("Energy"))
        {
            energy = true;
        }
        if (other.CompareTag("Health"))
        {
            health = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Medic"))
        {
            medic = false;
        }
        if (other.CompareTag("Energy"))
        {
            energy = false;
        }
        if (other.CompareTag("Health"))
        {
            health = false;
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
            this.siringa -= newValue;
            hptext.text = siringa.ToString();
            //reward.PlayOneShot(rewards[0]);
            Hizalabilir = true;
            //isSiringaEffect = true;
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
        movement.speed2 *= 2;
        yield return new WaitForSeconds(10f);
        movement.speed2 /= 2;
    }

}
