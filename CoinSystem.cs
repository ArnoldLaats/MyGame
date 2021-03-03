using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSystem : MonoBehaviour
{
    public PlayManager playManager;
    public MainMenuManager menuManager;
    [Space]
    public int coins;
    public Text coinsText;
    public int collectedCoins;

    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        coinsText.text = "" + PlayerPrefs.GetInt("Coins", coins).ToString();
    }

    public void UpdateCoins()
    {
        Debug.Log("Got Updated");
        collectedCoins = playManager.collectedCoins;
        coins += collectedCoins;
        PlayerPrefs.SetInt("Coins", coins);
        coinsText.text = "" + PlayerPrefs.GetInt("Coins", coins).ToString();
    }
}
