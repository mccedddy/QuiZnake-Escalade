using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    // Fields
    [HideInInspector]
    private GameObject item;
    [HideInInspector]
    private Button itemButton;
    [HideInInspector]
    private string itemName;
    [HideInInspector]
    private Image itemBackground;
    private string itemNumberString;
    public int itemNumber;

    private void Start()
    {
        item = transform.gameObject;
        itemButton = item.GetComponent<Button>();
        itemName = item.transform.GetChild(1).gameObject.GetComponent<Image>().sprite.name;
        itemBackground = item.transform.GetChild(0).gameObject.GetComponent<Image>();
        itemNumberString = item.name.Substring(6,2);
        try
        {
            itemNumber = int.Parse(itemNumberString);
        }
        catch
        {
            itemNumber = int.Parse(itemNumberString.Substring(0,1));
        }
    }
    private void Update()
    {
        // Change color if owned
        if (PlayerPrefs.GetString(itemName) == "true")
        {
            itemBackground.color = new Color32(255, 255, 255, 255);
        }
        else
        {
            itemBackground.color = new Color32(255, 255, 255, 100);
        }

        // Item click
        itemButton.onClick.AddListener(() =>
        {
            Shop.clicked = itemName;

            if (PlayerPrefs.GetString(itemName) == "true") // Equip
            {
                Shop.Equip();
            }
            else
            {
                if (itemNumber <= 25)
                {
                    Shop.itemPrice = 10;
                }
                if (itemNumber > 25 && itemNumber <= 37)
                {
                    Shop.itemPrice = 15;
                }
                if (itemNumber > 37)
                {
                    Shop.itemPrice = 20;
                }
                Shop.Buy();
            }
        });
    }
}
