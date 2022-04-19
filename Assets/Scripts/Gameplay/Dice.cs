using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private bool coroutineAllowed = true;
    public static bool clickable = true;

    // START
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[0];
        clickable = true;
    }

    // Button Click
    private void OnMouseDown()
    {
        if (clickable)
        {
            StartCoroutine("RollTheDice");
        }
    }

    // Die Roll
    public IEnumerator RollTheDice()
    {
        clickable = false;
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)   
        {
            randomDiceSide = Random.Range(0, 6);
            GameControl.SFX_ButtonClick.GetComponent<AudioSource>().Play();
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }
        GameControl.diceSideThrown = randomDiceSide + 1;
        GameControl.player1Position += GameControl.diceSideThrown;
        GameControl.MovePlayer();

        // Position limiter
        // Easy
        if (GameControl.stage == "1")
        {
            if (GameControl.player1Position >= 36)
            {
                GameControl.player1Position = 36;
            }
        }
        // Medium
        if (GameControl.stage == "2")
        {
            if (GameControl.player1Position >= 64)
            {
                GameControl.player1Position = 64;
            }
        }
        // Hard
        if (GameControl.stage == "3")
        {
            if (GameControl.player1Position >= 100)
            {
                GameControl.player1Position = 100;
            }
        }

        GameControl.checkedTile = false;
        clickable = true;
        coroutineAllowed = true;
    }
}
