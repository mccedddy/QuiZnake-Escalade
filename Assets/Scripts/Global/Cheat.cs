using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    [SerializeField] AudioSource FieldSFX_Coin;
    public static AudioSource SFX_Coin;
    private void Start()
    {
        SFX_Coin = FieldSFX_Coin;
    }
    public void CoinCheat()
    {
        Coins.AddCoin(100);
    }
}
