using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateName : MonoBehaviour
{
    void Update()
    {
        transform.gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("name");
    }
}
