using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FlashlightToggle : MonoBehaviour
{
    public GameObject lightGO; //light gameObject to work with
    public bool isOn = false; //is flashlight on or off?
    public int Insanity = 1; //Total Insanity meter
    public double Timer = 120; // The wait time between flashes
    public double CurrentTime = 0; //Current time for the timer;
    public bool Flicker = false;

    // Use this for initialization
    void Start()
    {
        //set default off
        lightGO.SetActive(isOn);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += 0.3;
        if(Insanity > 0)
        {
            Timer = 120 / Insanity;
        }
        if (CurrentTime > 61)
        {
            CurrentTime = 0;
        }

        if (Flicker == false)
        {
            if (CurrentTime > Timer - 1)
            {
                //Debug.Log("DOES IT");
                lightGO.SetActive(false);
                Flicker = true;
                CurrentTime = 0;
            }

        } else
        {
            if (CurrentTime > Timer/4)
            {
                //Debug.Log("How Quick");
                lightGO.SetActive(true);
                Flicker = false;
                CurrentTime = 0;
            }
        }
            
    
        //toggle flashlight on key down
        if(Input.GetKeyDown(KeyCode.C))
        {
            Insanity += 1;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            //toggle light
            isOn = !isOn;
            //turn light on
            
            if (Flicker == false)
                if (CurrentTime < Timer)
                {
                    if (isOn)
                    {
                        lightGO.SetActive(true);
                    }
                    //turn light off
                    else
                    {
                        lightGO.SetActive(false);

                    }
                }
        }
            
    }
}
