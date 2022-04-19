using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager musicManagerInstance;

    private void Update()
    {
        if (PlayerPrefs.GetString("backgroundMusic") == "false")
        {
            gameObject.GetComponent<AudioSource>().volume = 0;
        }
        else
        {
            gameObject.GetComponent<AudioSource>().volume = 0.25f;
        }
        // If level starts, stop menu music
        if (SceneManager.GetActiveScene().name == "Stage1-easy" ||
            SceneManager.GetActiveScene().name == "Stage1-medium" ||
            SceneManager.GetActiveScene().name == "Stage1-hard" ||
            SceneManager.GetActiveScene().name == "Stage2-easy" ||
            SceneManager.GetActiveScene().name == "Stage2-medium" ||
            SceneManager.GetActiveScene().name == "Stage2-hard" ||
            SceneManager.GetActiveScene().name == "Stage3-easy" ||
            SceneManager.GetActiveScene().name == "Stage3-medium" ||
            SceneManager.GetActiveScene().name == "Stage3-hard")
        {
            Destroy(gameObject);
        }
    }
    void Awake()
    {
        // Dont destroy music on switching scenes
        DontDestroyOnLoad(transform.gameObject);

        if (musicManagerInstance == null)
        {
            musicManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
