using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HTPControl : MonoBehaviour
{
    [SerializeField] Canvas canvas2;
    [SerializeField] Canvas canvas3;
    [SerializeField] Canvas canvas4;
    [SerializeField] Canvas canvas5;
    [SerializeField] Canvas canvas6;
    [SerializeField] Canvas canvas7;
    [SerializeField] Canvas canvas8;
    [SerializeField] Button next;

    private int currentCanvas = 1;
    private bool currentCanvasAdd = false;
    private bool loading = false;

    private void Start()
    {
        //htp = SceneManager.GetActiveScene();
    }
    private void Update()
    {
        next.onClick.AddListener(() =>
        {
            // Step counter
            if (currentCanvasAdd == false)
            {
                currentCanvas += 1;
                currentCanvasAdd = true;
            }

            // Next Step
            if (currentCanvas == 2)
                canvas2.enabled = true;
            if (currentCanvas == 3)
                canvas3.enabled = true;
            if (currentCanvas == 4)
                canvas4.enabled = true;
            if (currentCanvas == 5)
                canvas5.enabled = true;
            if (currentCanvas == 6)
                canvas6.enabled = true;
            if (currentCanvas == 7)
                canvas7.enabled = true;
            if (currentCanvas == 8)
                canvas8.enabled = true;

            // Back to Menu
            if (currentCanvas == 9)
            {
                if (loading == false)
                {
                    BeginLoadLevel();
                    loading = true;
                }
            }
        });
        currentCanvasAdd = false;
    }
    public void BeginLoadLevel()
    {
        Debug.Log("Loading");
        StartCoroutine(LoadLevelAsync());
    }
    private IEnumerator LoadLevelAsync()
    {
        var progress = SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);

        while (!progress.isDone)
        {
            // Check each frame if the scene has completed.
            yield return null;
        }

        // Code after this point is executed after the new scene has loaded
        Debug.Log("Scene Loaded");
        SceneManager.LoadScene("MainMenu");
    }
}
