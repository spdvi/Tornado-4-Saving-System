using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectConsole : MonoBehaviour
{
    private FPSLevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        //levelManager = GameObject.Find("LevelManager").GetComponent<FPSLevelManager>();
        levelManager = FindObjectOfType<FPSLevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            levelManager.PlayerOnConsole();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            levelManager.PlayerOutOfConsole();
        }
    }
}
