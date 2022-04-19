using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXVolume : MonoBehaviour
{
    void Update()
    {
        if (PlayerPrefs.GetString("soundEffects") == "false")
        {
            gameObject.GetComponent<AudioSource>().volume = 0;
        }
        else
        {
            gameObject.GetComponent<AudioSource>().volume = 1;
        }
    }
}
