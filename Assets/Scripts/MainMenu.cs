using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            SceneManager.LoadScene("Level1");
        }

        if (Input.GetKeyDown("e"))
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }

    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}

