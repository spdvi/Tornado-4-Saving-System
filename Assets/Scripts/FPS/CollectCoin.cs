using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class CollectCoin : MonoBehaviour, IJsonSaveable
{
    private FPSLevelManager levelManager;
    private bool hasBeenCollected = false;

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
            //Destroy(this.gameObject);
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            hasBeenCollected = true;
        }
    }

    public JToken CaptureAsJToken()
    {
        return JToken.FromObject(hasBeenCollected);
    }

    public void RestoreFromJToken(JToken state)
    {
        hasBeenCollected = state.ToObject<bool>();
        if (hasBeenCollected)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<Collider>().enabled = true;
        }
    }
}
