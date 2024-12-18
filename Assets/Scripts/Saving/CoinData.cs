using Newtonsoft.Json.Linq;

[System.Serializable]
public class CoinData
{
    public string CoinName { get; set; }
    public JToken CoinPosition { get; set; }

    public CoinData()
    {
        
    }

    public CoinData(string coinName, JToken coinPosition)
    {
        CoinName = coinName;
        CoinPosition = coinPosition;
    }
}
