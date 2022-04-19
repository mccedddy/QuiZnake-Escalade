using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBGMVolume : MonoBehaviour
{
    void Update()
    {
        if (PlayerPrefs.GetString("backgroundMusic") == "false")
        {
            gameObject.GetComponent<AudioSource>().volume = 0;
        }
        else
        {
            gameObject.GetComponent<AudioSource>().volume = 1;
        }
    }
}
