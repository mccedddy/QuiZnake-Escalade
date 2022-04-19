using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeName : MonoBehaviour
{
    [SerializeField] Button changeName;
    [SerializeField] Button popUpButton;
    [SerializeField] Canvas popUpCanvas;
    [SerializeField] TextMeshProUGUI playerName;
    [SerializeField] TMP_InputField inputField;

    void Update()
    {
        // Load player namer
        playerName.text = PlayerPrefs.GetString("name");

        // Open pop up
        changeName.onClick.AddListener(() =>
        {
            popUpCanvas.enabled = true;
        });

        // Set new name
        popUpButton.onClick.AddListener(() =>
        {
            if (inputField.text == "") { }
            else
            PlayerPrefs.SetString("name", inputField.text);
            popUpCanvas.enabled = false;
        });
    }
}
