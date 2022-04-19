using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] Button button_left;
    [SerializeField] Button button_right;
    [SerializeField] GameObject character;
    [SerializeField] TextMeshProUGUI characterName;

    private bool switched = false;

    private void Update()
    {
        // Load Character
        LoadCharacter();

        // Button
        // Right
        button_right.onClick.AddListener(() =>
        {
            if (PlayerPrefs.GetString("characterEquipped") == "joseRizal")
            {
                if (switched == false)
                {
                    if (PlayerPrefs.GetString("Atlas_gregoriaDeJesus_idle1") == "true")
                        ToGregoriaDeJesus();
                    else if (PlayerPrefs.GetString("Atlas_lapuLapu_idle1") == "true")
                        ToLapuLapu();
                    else if (PlayerPrefs.GetString("Atlas_gabrielaSilang_idle1") == "true")
                        ToGabrielaSilang();
                }
            }
            else if (PlayerPrefs.GetString("characterEquipped") == "gregoriaDeJesus")
            {
                if (switched == false)
                {
                    if (PlayerPrefs.GetString("Atlas_lapuLapu_idle1") == "true")
                        ToLapuLapu();
                    else if (PlayerPrefs.GetString("Atlas_gabrielaSilang_idle1") == "true")
                        ToGabrielaSilang();
                    else
                        ToJoseRizal();
                }
            }
            else if (PlayerPrefs.GetString("characterEquipped") == "lapuLapu")
            {
                if (switched == false)
                {
                    if (PlayerPrefs.GetString("Atlas_gabrielaSilang_idle1") == "true")
                        ToGabrielaSilang();
                    else
                        ToJoseRizal();
                }
            }
            else if (PlayerPrefs.GetString("characterEquipped") == "gabrielaSilang")
            {
                if (switched == false)
                {
                    ToJoseRizal();
                }
            }
            switched = true;
        });

        // Left
        button_left.onClick.AddListener(() =>
        {
            if (PlayerPrefs.GetString("characterEquipped") == "joseRizal")
            {
                if (switched == false)
                {
                    if (PlayerPrefs.GetString("Atlas_gabrielaSilang_idle1") == "true")
                        ToGabrielaSilang();
                    else if (PlayerPrefs.GetString("Atlas_lapuLapu_idle1") == "true")
                        ToLapuLapu();
                    else if (PlayerPrefs.GetString("Atlas_gregoriaDeJesus_idle1") == "true")
                        ToGregoriaDeJesus();
                }
            }
            else if (PlayerPrefs.GetString("characterEquipped") == "gabrielaSilang")
            {
                if (switched == false)
                {
                    if (PlayerPrefs.GetString("Atlas_lapuLapu_idle1") == "true")
                        ToLapuLapu();
                    else if (PlayerPrefs.GetString("Atlas_gregoriaDeJesus_idle1") == "true")
                        ToGregoriaDeJesus();
                    else
                        ToJoseRizal();
                }
            }
            else if (PlayerPrefs.GetString("characterEquipped") == "lapuLapu")
            {
                if (switched == false)
                {
                    if (PlayerPrefs.GetString("Atlas_gregoriaDeJesus_idle1") == "true")
                        ToGregoriaDeJesus();
                    else
                        ToJoseRizal();
                }
            }
            else if (PlayerPrefs.GetString("characterEquipped") == "gregoriaDeJesus")
            {
                if (switched == false)
                {
                    ToJoseRizal();
                }
            }
            switched = true;
        });
        switched = false;
    }
    private void ToJoseRizal()
    {
        PlayerPrefs.SetString("characterEquipped", "joseRizal");
    }
    private void ToGregoriaDeJesus()
    {
        PlayerPrefs.SetString("characterEquipped", "gregoriaDeJesus");
    }
    private void ToLapuLapu()
    {
        PlayerPrefs.SetString("characterEquipped", "lapuLapu");
    }
    private void ToGabrielaSilang()
    {
        PlayerPrefs.SetString("characterEquipped", "gabrielaSilang");
    }
    private void LoadCharacter()
    {
        character.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Characters/Animation/Controller_" + PlayerPrefs.GetString("characterEquipped")) as RuntimeAnimatorController;
        if (PlayerPrefs.GetString("characterEquipped") == "joseRizal")
            characterName.text = "Jose Rizal";
        if (PlayerPrefs.GetString("characterEquipped") == "gregoriaDeJesus")
            characterName.text = "Gregoria De Jesus";
        if (PlayerPrefs.GetString("characterEquipped") == "lapuLapu")
            characterName.text = "Lapu-Lapu";
        if (PlayerPrefs.GetString("characterEquipped") == "gabrielaSilang")
            characterName.text = "Gabriela Silang";
    }
}
