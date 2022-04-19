using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Coins : MonoBehaviour
{
    private static int coins;
    private static int newcoins;
    public static void AddCoin(int coinsToAdd)
    {
        coins = PlayerPrefs.GetInt("coins");
        newcoins = coins + coinsToAdd;
        coins = newcoins;
        if (SceneManager.GetActiveScene().name == "Settings")
        {
            Cheat.SFX_Coin.GetComponent<AudioSource>().Play();
        }
        else
        {
            GameControl.SFX_Coin.GetComponent<AudioSource>().Play();
        }

        PlayerPrefs.SetInt("coins", coins);
    }
    public static void RemoveCoin(int coinsToRemove)
    {
        coins = PlayerPrefs.GetInt("coins");
        newcoins = coins - coinsToRemove;
        if (newcoins < 0)
        {
            newcoins = coins;
        }
        else
        {
            coins = newcoins;
            Shop.SFX_Coin.GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("coins", coins);
        }
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("coins") == false)
        {
            coins = 0;
            PlayerPrefs.SetInt("coins", coins);
        }
    }
    private void Update()
    {
        GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("coins").ToString();
    }
}
