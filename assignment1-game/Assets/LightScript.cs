using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public GameObject flashlight;
    FlashlightToggle ft;
    Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        ft = flashlight.GetComponent<FlashlightToggle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ft.currentInsanity <= 25)
        {
            light.intensity = 3.0f;
        }
        else if (ft.currentInsanity <= 50)
        {
            light.intensity = 2.0f;
        }
        else if (ft.currentInsanity <= 70)
        {
            light.intensity = 1.5f;
        }
        else
        {
            light.intensity = 1.0f;
        }
    }
}
