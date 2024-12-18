using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class CoinsManager : MonoBehaviour, IJsonSaveable
{
    private int coins;
    public FPSLevelManager levelManager;

    public void UpdateCoinCount()
    {
        coins++;
        levelManager.CheckCoinsAndUpdateUI(coins);
    }
    
    public JToken CaptureAsJToken()
    {
        return JToken.FromObject(coins);
    }

    public void RestoreFromJToken(JToken state)
    {
        coins = state.ToObject<int>();
        levelManager.CheckCoinsAndUpdateUI(coins);
    }
}
