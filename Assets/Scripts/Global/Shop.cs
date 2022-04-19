using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Shop : MonoBehaviour
{
    [SerializeField] Canvas fieldPopUp;
    [SerializeField] Button fieldPopUpYes;
    [SerializeField] Button fieldPopUpNo;
    [SerializeField] GameObject fieldSFX_Coin;
    [SerializeField] TextMeshProUGUI fieldPopUpTitle;
    [SerializeField] TextMeshProUGUI fieldPopUpText;
    [SerializeField] Canvas boardCanvas;
    [SerializeField] Canvas avatarCanvas;
    [SerializeField] Button boardButton;
    [SerializeField] Button avatarButton;

    // Fields
    public static Canvas popUp;
    public static Button popUpYes;
    public static Button popUpNo;
    public static TextMeshProUGUI popUpTitle;
    public static TextMeshProUGUI popUpText;
    public static string clicked = "";
    public static GameObject SFX_Coin;
    private static bool coinRemoved = false;
    public static int itemPrice;

    private void Start()
    {
        popUp = fieldPopUp;
        popUpYes = fieldPopUpYes;
        popUpNo = fieldPopUpNo;
        popUpTitle = fieldPopUpTitle;
        popUpText = fieldPopUpText;
        SFX_Coin = fieldSFX_Coin;
    }

    private void Update()
    {
        boardButton.onClick.AddListener(() =>
        {
            avatarCanvas.enabled = false;
            boardCanvas.enabled = true;
        });
        avatarButton.onClick.AddListener(() =>
        {
            avatarCanvas.enabled = true;
            boardCanvas.enabled = false;
        });
    }
    public static void Buy()
    {
        popUp.enabled = true;
        popUpTitle.text = "Buy";
        popUpText.text = "Do you want to buy it?";

        popUpYes.onClick.AddListener(() =>
        {
            if (PlayerPrefs.GetInt("coins") >= itemPrice)
            {
                if (coinRemoved == false)
                {
                    Coins.RemoveCoin(itemPrice);
                    coinRemoved = true;
                }
                PlayerPrefs.SetString(clicked, "true");
            }
            popUp.enabled = false;
        });
        popUpNo.onClick.AddListener(() =>
        {
            popUp.enabled = false;
        });

        coinRemoved = false;
    }
    public static void Equip()
    {
        popUp.enabled = true;
        popUpTitle.text = "Equip";
        popUpText.text = "Do you want to equip it?";

        popUpYes.onClick.AddListener(() =>
        {
            if (clicked.Substring(0,1) == "6")
            {
                PlayerPrefs.SetString("6x6Equipped", clicked);
            }
            if (clicked.Substring(0, 1) == "8")
            {
                PlayerPrefs.SetString("8x8Equipped", clicked);
            }
            if (clicked.Substring(0, 1) == "1")
            {
                PlayerPrefs.SetString("10x10Equipped", clicked);
            }
            if (clicked.Substring(6, 2) == "jo")
            {
                PlayerPrefs.SetString("characterEquipped", "joseRizal");
            }
            if (clicked.Substring(6, 2) == "gr")
            {
                PlayerPrefs.SetString("characterEquipped", "gregoriaDeJesus");
            }
            if (clicked.Substring(6, 2) == "la")
            {
                PlayerPrefs.SetString("characterEquipped", "lapuLapu");
            }
            if (clicked.Substring(6, 2) == "ga")
            {
                PlayerPrefs.SetString("characterEquipped", "gabrielaSilang");
            }
            popUp.enabled = false;
        });
        popUpNo.onClick.AddListener(() =>
        {
            popUp.enabled = false;
        });
    }
}
