using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void BeginLoadLevel()
    {
        Debug.Log("Loading");
        StartCoroutine(LoadMenuAsync());
    }
    private IEnumerator LoadMenuAsync()
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