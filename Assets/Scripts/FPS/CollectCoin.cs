using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    private FPSLevelManager levelManager;

    private void OnEnable()
    {
        levelManager = GameObject.FindObjectOfType<FPSLevelManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Collect Coin");
            levelManager.CoinCollected();
            Destroy(this.gameObject);
        }
    }
}
