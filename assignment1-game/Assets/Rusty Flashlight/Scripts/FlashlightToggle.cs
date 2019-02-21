using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FlashlightToggle : MonoBehaviour
{
    public GameObject lightGO; //light gameObject to work with
    public bool isOn = false; //is flashlight on or off?
    public int MAX_INSANITY = 100; //maximum insanity
    public int currentInsanity = 0; //Current insanity
    public double Timer = 120; // The wait time between flashes
    public double CurrentTime = 0; //Current time for the timer;
    public bool Flicker = false;
    public GameObject CheckCloseTo;
    public int Range = 2;
    public float insanityIncreaseInterval = 1.0f; //time it takes for insanity to increase in seconds (Decrease to make insanity increase faster)
    private float time = 0.0f;
    public float flickerChanceInterval = 1.0f; //Lights will have a chance to flicker after this many seconds (decrease for more frequent flickers)
    public float jumpScareInterval = 1.0f;
    private float jumpScareTime = 0.0f;
    private float flickerTime = 0.0f;
    private string currentlyPlaying;
    public GameObject scareImage1;
    public GameObject scareImage2;
    private GameObject activateImage;
    private bool jumpScare = false;
    private float scareTime = 0.0f;
    private float jumpDuration = 0.1f;
    AudioSource[] audio;
    // Use this for initialization
    void Start()
    {
        audio = GetComponents<AudioSource>();
        //set lights on by default
        turnLightOn();
    }

    // Update is called once per frame
    void Update()
    {
        //if close to campfire decrease currentInsanity 3x quicker then you do increase currentInsanity
        /*
        if (Vector3.Distance(transform.position, CheckCloseTo.transform.position) < Range)
        {
            if(currentInsanity > 0)
            {
                if (time >= insanityIncreaseInterval / 3)
                {
                    currentInsanity -= 1;
                    CurrentTime = 0;
                    time = 0.0f;
                }
                
            }
        }
        */

        if (isOn)
        if(currentInsanity < MAX_INSANITY)
        {
            time += Time.deltaTime;
            if (time >= insanityIncreaseInterval)
            {
                time = 0.0f;
                currentInsanity += 1;
                if(currentInsanity < 20)
                {
                    if(currentlyPlaying != "stageone")
                    {
                        currentlyPlaying = "stageone";
                        audio[5].Stop();
                        audio[6].Play();
                    }
                }
                if (currentInsanity >= 20 && currentInsanity < 40)
                {
                    if (currentlyPlaying != "stagetwo")
                    {
                        currentlyPlaying = "stagetwo";
                        audio[6].Stop();
                        audio[4].Stop();
                        audio[5].Play();
                    }
                }
                if (currentInsanity >= 40 && currentInsanity < 60)
                {
                    if (currentlyPlaying != "stagethree")
                    {
                        currentlyPlaying = "stagethree";
                        audio[5].Stop();
                        audio[3].Stop();
                        audio[4].Play();
                    }
                }
                if (currentInsanity >= 60 && currentInsanity < 80)
                {
                    if (currentlyPlaying != "stagefour")
                    {
                        currentlyPlaying = "stagefour";
                        audio[4].Stop();
                        audio[2].Stop();
                        audio[3].Play();
                    }
                }
                if (currentInsanity >= 80)
                {
                    if (currentlyPlaying != "stagefive")
                    {
                        currentlyPlaying = "stagefive";
                        audio[3].Stop();
                        audio[2].Play();
                    }
                }
            }
        }
        if (lightGO.activeSelf)
        {
            if (Flicker == false)
            {
                flickerTime += Time.deltaTime;
                if (flickerTime >= flickerChanceInterval)
                {
                    flickerTime = 0.0f;
                    //currentInsanity += 1; maybe make them more insane with each flicker
                    if (Random.Range(0.0f, 100.0f) < currentInsanity)
                    {
                        turnLightOff();
                        Flicker = true;
                        Timer = Random.Range(100.0f, 250.0f / (1 + currentInsanity / 10));
                        CurrentTime = 0;
                    }
                }
            }
        }
        else
        {
            if (Flicker == true)
            {
                CurrentTime += 1;
                if (CurrentTime > Timer / 4)
                {
                    //Debug.Log("How Quick");
                    turnLightOn();
                    Flicker = false;
                    CurrentTime = 0;
                }
            }
        }



        //toggle flashlight on key down
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentInsanity += 1;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            
            
            if (Flicker == false)
                if (CurrentTime < Timer)
                {
                    //toggle light
                    //turn light on
                    isOn = !isOn;
                    if (isOn)
                    {
                        turnLightOn();
                    }
                    //turn light off
                    else
                    {
                        turnLightOff();

                    }
                }
        }

        if (currentInsanity >= 50)
        {
            if(jumpScare == false) {
                jumpScareTime += Time.deltaTime;
                if (jumpScareTime >= jumpScareInterval)
                {   
                    jumpScareTime = 0;
                    int rand = Random.Range(0, (25 - Mathf.RoundToInt((currentInsanity / 5))));
                    if (rand == 1)
                    {
                        int imageNum = Random.Range(0, 2);
                        if (imageNum == 0)
                        {
                            activateImage = scareImage1;
                        }
                        if (imageNum == 1)
                        {
                            activateImage = scareImage2;
                        }
                        audio[7].Play();
                        activateImage.SetActive(true);
                        jumpScare = true;
                    }
                }
            }
        }
        if(jumpScare == true)
        {
            scareTime += Time.deltaTime;
            if(scareTime >= jumpDuration)
            {
                scareTime = 0;
                activateImage.SetActive(false);
                jumpScare = false;
            }
        }
    }
    //Call this function to turn the light on
    void turnLightOn()
    {
        lightGO.SetActive(true);
        audio[0].Play();
    }

    //Call this function to turn the light off
    void turnLightOff()
    {
        lightGO.SetActive(false);
        audio[1].Play();
    }
}
