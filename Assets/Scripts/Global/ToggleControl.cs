using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleControl : MonoBehaviour
{
    [SerializeField] Toggle backgroundMusic;
    [SerializeField] Toggle soundEffects;

    // Start is called before the first frame update
    void Start()
    {
        // Add settings to playerprefs
        if (PlayerPrefs.HasKey("backgroundMusic") == false && PlayerPrefs.HasKey("soundEffects") == false)
        {
            PlayerPrefs.SetString("backgroundMusic", "true");
            PlayerPrefs.SetString("soundEffects", "true");
        }

        // BGM load
        if (PlayerPrefs.GetString("backgroundMusic") == "true")
            backgroundMusic.isOn = true;
        else
            backgroundMusic.isOn = false;

        // SFX load
        if (PlayerPrefs.GetString("soundEffects") == "true")
            soundEffects.isOn = true;
        else
            soundEffects.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        // BGM Switch
        if (backgroundMusic.isOn == true)
            PlayerPrefs.SetString("backgroundMusic", "true");
        else
            PlayerPrefs.SetString("backgroundMusic", "false");

        // SFX Switch
        if (soundEffects.isOn == true)
            PlayerPrefs.SetString("soundEffects", "true");
        else
            PlayerPrefs.SetString("soundEffects", "false");
    }
}
