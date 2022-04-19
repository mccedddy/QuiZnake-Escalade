using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class Popup : MonoBehaviour
{
    // Inspector Fields
    [SerializeField] Button fieldPopUpButton;
    [SerializeField] TextMeshProUGUI fieldPopUpTitle;
    [SerializeField] TextMeshProUGUI fieldPopUpText;
    [SerializeField] TMP_InputField fieldInputField;

    // Fields
    public static Canvas popUpCanvas;
    public static Button popUpButton;
    public static TextMeshProUGUI popUpTitle;
    public static TextMeshProUGUI popUpText;
    public static TMP_InputField inputField;
    public static bool tileHasInput = false;
    public static bool answerDone = false;


    // START
    void Start()
    {
        // Set pop up
        popUpCanvas = GetComponent<Canvas>();

        // Set variables
        popUpButton = fieldPopUpButton;
        popUpTitle = fieldPopUpTitle;
        popUpText = fieldPopUpText;
        inputField = fieldInputField;
        tileHasInput = false;
        answerDone = false;

        // Hide pop up and input field
        popUpCanvas.enabled = false;
        inputEnabled(false);
    }

    // UPDATE
    void Update()
    {
        if (GameControl.gameOver == false)
        {
            // OK Button
            // No input
            if (tileHasInput == false && answerDone == false)
            {
                popUpButton.onClick.AddListener(() =>
                {
                    Dice.clickable = true;
                    inputEnabled(false);
                    popUpCanvas.enabled = false;
                });
            }

            // Has input
            else
            {
                popUpButton.onClick.AddListener(() =>
                {
                    // Correct Answer
                    if (inputField.text.ToLower() == Tile.answer.ToLower() && answerDone == false)
                    {
                        GameControl.SFX_Correct.GetComponent<AudioSource>().Play();
                        if (Tile.tileStepped == "consequence")
                        {
                            DefaultPopUp("Correct!");
                        }

                        if (Tile.tileStepped == "question")
                        {
                            DefaultPopUp("Correct!\nMove 2 steps forward");
                            GameControl.ClimbPlayer(GameControl.player1Position + 2);
                        }
                    }

                    // Wrong Answer
                    else if (inputField.text.ToLower() != Tile.answer.ToLower() && answerDone == false)
                    {
                        GameControl.SFX_Wrong.GetComponent<AudioSource>().Play();
                        if (Tile.tileStepped == "consequence")
                        {
                            DefaultPopUp("Wrong!\n- 1 Heart");
                            GameControl.heart = GameControl.heart - 1;
                            GameControl.SFX_Hit.GetComponent<AudioSource>().Play();
                        }

                        if (Tile.tileStepped == "question")
                        {
                            DefaultPopUp("Wrong!\nMove 1 step backward");
                            GameControl.ClimbPlayer(GameControl.player1Position - 1);
                        }
                    }
                    Tile.tileStepped = "";
                });
            }
        }
    }
    public static void inputEnabled(bool enabled)
    {
        if (enabled == true)
        {
            inputField.enabled = true;
            inputField.image.enabled = true;
            tileHasInput = true;
            answerDone = false;
        }
        else
        {
            inputField.enabled = false;
            inputField.image.enabled = false;
            tileHasInput = false;
        }
    }
    public static void DefaultPopUp(string message)
    {
        Dice.clickable = false;
        popUpCanvas.enabled = true;
        popUpText.text = message;
        answerDone = true;
        inputField.text = "";
        inputEnabled(false);
    }

    private static void Debugger(string note)
    {
        Debug.Log(note + 
                    " \nCanvasEnabled = " + popUpCanvas.enabled +
                    " AnswerDone = " + answerDone +
                    " TileHasInput = " + tileHasInput);
    }
}
