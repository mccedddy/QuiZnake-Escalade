using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlock : MonoBehaviour
{
    [SerializeField] Button stage1;
    [SerializeField] Button stage2;
    [SerializeField] Button stage3;

    private void Start()
    {
        // Set cleared
        if (!PlayerPrefs.HasKey("stage1Cleared"))
        {
            PlayerPrefs.SetString("stage1Cleared", "false");
        }
        if (!PlayerPrefs.HasKey("stage2Cleared"))
        {
            PlayerPrefs.SetString("stage2Cleared", "false");
        }


        if (PlayerPrefs.GetString("stage1Cleared") == "true")
        {
            stage2.interactable = true;
        }
        else
        {
            stage2.interactable = false;
        }

        if (PlayerPrefs.GetString("stage2Cleared") == "true")
        {
            stage3.interactable = true;
        }
        else
        {
            stage3.interactable = false;
        }
    }
}
