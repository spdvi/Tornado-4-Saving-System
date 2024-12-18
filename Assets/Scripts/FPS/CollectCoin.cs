using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class CollectCoin : MonoBehaviour, IJsonSaveable
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

    public JToken CaptureAsJToken()
    {
        CoinData nombreYPosicion = new CoinData();
        nombreYPosicion.CoinName = this.gameObject.name;
        nombreYPosicion.CoinPosition = this.gameObject.transform.position.ToToken();
        JToken nombreYPosicionJToken = JToken.FromObject(nombreYPosicion);
        return nombreYPosicionJToken;
    }

    public void RestoreFromJToken(JToken state)
    {
        throw new NotImplementedException();
    }
}
