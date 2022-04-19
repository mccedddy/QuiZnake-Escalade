using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    private void Start() // Initialize Save Data
    {
        if (!PlayerPrefs.HasKey("coins")) // Coins
        {
            PlayerPrefs.SetInt("coins", 0);
        }
        if (!PlayerPrefs.HasKey("6x6Default")) // Owned Boards
        {
            PlayerPrefs.SetString("6x6Default", "true");
        }
        if (!PlayerPrefs.HasKey("6x6Cab"))
        {
            PlayerPrefs.SetString("6x6Cab", "true");
        }
        if (!PlayerPrefs.HasKey("6x6IceCream"))
        {
            PlayerPrefs.SetString("6x6IceCream", "true");
        }
        if (!PlayerPrefs.HasKey("6x6RedBlack"))
        {
            PlayerPrefs.SetString("6x6RedBlack", "true");
        }
        if (!PlayerPrefs.HasKey("6x6RedWhite"))
        {
            PlayerPrefs.SetString("6x6RedWhite", "true");
        }
        if (!PlayerPrefs.HasKey("6x6VioletPinkBlack"))
        {
            PlayerPrefs.SetString("6x6VioletPinkBlack", "true");
        }
        if (!PlayerPrefs.HasKey("6x6Xmas"))
        {
            PlayerPrefs.SetString("6x6Xmas", "true");
        }
        if (!PlayerPrefs.HasKey("8x8Default"))
        {
            PlayerPrefs.SetString("8x8Default", "true");
        }
        if (!PlayerPrefs.HasKey("8x8Cab"))
        {
            PlayerPrefs.SetString("8x8Cab", "true");
        }
        if (!PlayerPrefs.HasKey("8x8IceCream"))
        {
            PlayerPrefs.SetString("8x8IceCream", "true");
        }
        if (!PlayerPrefs.HasKey("8x8RedBlack"))
        {
            PlayerPrefs.SetString("8x8RedBlack", "true");
        }
        if (!PlayerPrefs.HasKey("8x8RedWhite"))
        {
            PlayerPrefs.SetString("8x8RedWhite", "true");
        }
        if (!PlayerPrefs.HasKey("8x8PinkVioletBlack"))
        {
            PlayerPrefs.SetString("8x8PinkVioletBlack", "true");
        }
        if (!PlayerPrefs.HasKey("8x8Xmas"))
        {
            PlayerPrefs.SetString("8x8Xmas", "true");
        }
        if (!PlayerPrefs.HasKey("10x10Default"))
        {
            PlayerPrefs.SetString("10x10Default", "true");
        }
        if (!PlayerPrefs.HasKey("10x10Cab"))
        {
            PlayerPrefs.SetString("10x10Cab", "true");
        }
        if (!PlayerPrefs.HasKey("10x10IceCreamWhite"))
        {
            PlayerPrefs.SetString("10x10IceCreamWhite", "true");
        }
        if (!PlayerPrefs.HasKey("10x10RedBlack"))
        {
            PlayerPrefs.SetString("10x10RedBlack", "true");
        }
        if (!PlayerPrefs.HasKey("10x10RedWhite"))
        {
            PlayerPrefs.SetString("10x10RedWhite", "true");
        }
        if (!PlayerPrefs.HasKey("10x10IceCreamBlack"))
        {
            PlayerPrefs.SetString("10x10IceCreamBlack", "true");
        }
        if (!PlayerPrefs.HasKey("10x10Xmas"))
        {
            PlayerPrefs.SetString("10x10Xmas", "true");
        }
        if (!PlayerPrefs.HasKey("6x6Equipped")) // Equipped Boards
        {
            PlayerPrefs.SetString("6x6Equipped", "6x6Default");
        }
        if (!PlayerPrefs.HasKey("8x8Equipped"))
        {
            PlayerPrefs.SetString("8x8Equipped", "8x8Default");
        }
        if (!PlayerPrefs.HasKey("10x10Equipped"))
        {
            PlayerPrefs.SetString("10x10Equipped", "10x10Default");
        }
        if (!PlayerPrefs.HasKey("name")) // Player Name
        {
            PlayerPrefs.SetString("name", "Player");
        }
        if (!PlayerPrefs.HasKey("Atlas_joseRizal_idle1")) // Owned Character
        {
            PlayerPrefs.SetString("Atlas_joseRizal_idle1", "true");
        }
        if (!PlayerPrefs.HasKey("characterEquipped")) // Equipped Character
        {
            PlayerPrefs.SetString("characterEquipped", "joseRizal");
        }
    }
    public static void Save()
    {
        PlayerPrefs.SetString("hasSave", "true");
        // Stage
        PlayerPrefs.SetString("stage", GameControl.stage);
        PlayerPrefs.SetString("difficulty", GameControl.difficulty);
        // Heart
        PlayerPrefs.SetInt("heart", GameControl.heart);
        // Position
        PlayerPrefs.SetInt("player1StartWaypoint", GameControl.player1StartWaypoint);
        PlayerPrefs.SetInt("player1Position", GameControl.player1Position);
        PlayerPrefs.SetInt("waypointIndex", GameControl.player1.GetComponent<FollowThePath>().waypointIndex);
    }
    public static void Continue()
    {
        if (PlayerPrefs.GetString("hasSave") == "true")
        {
            SceneManager.LoadScene("Stage" + PlayerPrefs.GetString("stage") + "-" + 
                                            PlayerPrefs.GetString("difficulty"));
            PlayerPrefs.SetString("continued", "true");
        }
    }
    public static void DeleteSave()
    {
        PlayerPrefs.DeleteKey("stage");
        PlayerPrefs.DeleteKey("difficulty");
        PlayerPrefs.DeleteKey("heart");
        PlayerPrefs.DeleteKey("player1StartWaypoint");
        PlayerPrefs.DeleteKey("player1Position");
        PlayerPrefs.DeleteKey("waypointIndex");
        PlayerPrefs.SetString("hasSave", "false");
        PlayerPrefs.SetString("continued", "false");
        
    }
    public static void Load()
    {
        GameControl.heart = PlayerPrefs.GetInt("heart");
        GameControl.player1StartWaypoint = PlayerPrefs.GetInt("player1StartWaypoint");
        GameControl.player1Position = PlayerPrefs.GetInt("player1Position");
        GameControl.player1.GetComponent<FollowThePath>().waypointIndex = PlayerPrefs.GetInt("waypointIndex");
    }
    public static void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }
}
