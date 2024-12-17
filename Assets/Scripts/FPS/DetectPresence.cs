using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPresence : MonoBehaviour
{
    public Light light;
    private float lightIntensity = 0.1f;
    private float elapsedTime = 0;
    private void OnTriggerEnter(Collider other)
    {
        light.enabled = true;
        Debug.Log("Light is on");
        elapsedTime = 0;
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (elapsedTime < 1.0f)
        {
            elapsedTime += Time.deltaTime;
        }
        else
        {
            light.intensity += 0.5f;
            elapsedTime = 0;
            //Debug.Log("Light++");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        light.enabled = false;
        light.intensity = 0f;
        Debug.Log("Light is off");
    }
}
