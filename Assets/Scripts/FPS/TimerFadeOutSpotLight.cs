using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerFadeOutSpotLight : MonoBehaviour
{
    public Light spotLight;
    public float timeToFadeOut;
    public float time;
    private float elapsedTime;
    private float decreaseRatio;
    
    // Start is called before the first frame update
    void Start()
    {
        decreaseRatio = spotLight.intensity / (timeToFadeOut * 10);
        time = timeToFadeOut;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            if (elapsedTime < 0.1f)
            {
                elapsedTime += Time.deltaTime;
            }
            else
            {
                time -= elapsedTime;
                elapsedTime = 0;
                spotLight.intensity -= decreaseRatio;
            }
        }
    }
}
