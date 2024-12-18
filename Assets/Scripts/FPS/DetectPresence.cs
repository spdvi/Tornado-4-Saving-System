using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class DetectPresence : MonoBehaviour, IJsonSaveable
{
    public Light light;
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

    public JToken CaptureAsJToken()
    {
        JToken lightIntensityJToken = JToken.FromObject(light.intensity);
        return lightIntensityJToken;
    }

    public void RestoreFromJToken(JToken state)
    {
        light.intensity = state.ToObject<float>();
    }
}
