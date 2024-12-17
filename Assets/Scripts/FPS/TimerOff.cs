using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TimerOff : MonoBehaviour
{
    public Light spotLight;
    public float countDownTime = 5f;
    
    private bool timerOn = false;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            timerOn = true;
        }

        if (timerOn)
        {
            if (countDownTime > 0)
            {
                countDownTime -= Time.deltaTime;
            }
            else
            {
                spotLight.enabled = false;
            }
        }
        
    }
}
