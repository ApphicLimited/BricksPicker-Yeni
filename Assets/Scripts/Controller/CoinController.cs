using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinController : MonoBehaviour
{
    public Coin CoinPrefab;
    public TMP_Text TextCoin;

    private int collectedCoins;
    public int CollectedCoins
    {
        get
        {
            return collectedCoins;
        }
        set
        {
            collectedCoins = value;
            TextCoin.text = collectedCoins.ToString();
        }
    }
}
