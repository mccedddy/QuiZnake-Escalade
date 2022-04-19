using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UpdateCharacter : MonoBehaviour
{
    private static string character;
    public Dictionary<string, Sprite> dictSprites = new Dictionary<string, Sprite>();
    void Start()
    {
        character = PlayerPrefs.GetString("characterEquipped");
        Sprite[] sprites = Resources.LoadAll<Sprite>("Characters/Atlas_" + character);

        foreach (Sprite sprite in sprites)
        {
            dictSprites.Add(sprite.name, sprite);
        }
    }
    //GetComponent<SpriteRenderer>().sprite = dictSprites[name];
    void Update()
    {
        character = PlayerPrefs.GetString("characterEquipped");
        transform.GetComponent<Image>().sprite = dictSprites["Atlas_" + character + "_idle1"];
    }
}
