using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    GameManager gm;

    void Start()
    {
        Resume();
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (GameIsPaused)
            {
                Resume();

            } else
            {
                Pause();
            }        

            gm.isPaused = GameIsPaused;
        }

        if (Input.GetKeyDown("r"))
        {
            Resume();
        }

        if (Input.GetKeyDown("m"))
        {
            SceneManager.LoadScene("Menu");
        }

        if (Input.GetKeyDown("q"))
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; 
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0; // freeze the game
        GameIsPaused = true;
    }
}
