using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SplashSequence : MonoBehaviour
{
    public int sceneNumber;
    private Slider slider;
    private bool finishedLoading = false;
    private TextMeshProUGUI loadingText;

    // Update is called once per frame
    void Start()
    {
        if (sceneNumber == 0)
        {
            StartCoroutine(ToSplashTwo());
        }
        if (sceneNumber == 1)
        {
            slider = GameObject.Find("Slider").GetComponent<Slider>();
            loadingText = GameObject.Find("Text_loading").GetComponent<TextMeshProUGUI>();
        }
    }
    private void Update()
    {
        if (sceneNumber == 1)
        {
            if (slider.value == 1) 
            {
                finishedLoading = true;
            }
            else
            {
                slider.value += 0.005f;
            }
            loadingText.text = "Loading " + string.Format("{0:0}", slider.value * 100) + "%";
        }
        if (finishedLoading)
        {
            StartCoroutine(ToMainMenu());
            finishedLoading = false;
        }
    }
    IEnumerator ToSplashTwo()
    {
        yield return new WaitForSeconds(3);
        sceneNumber = 1;
        SceneManager.LoadScene(1);
    }
    IEnumerator ToMainMenu()
    {
        yield return new WaitForSeconds(1);
        sceneNumber = 2;
        SceneManager.LoadScene(2);
    }
}
