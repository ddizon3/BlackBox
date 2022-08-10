using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{

    [SerializeField] Text lives;
    public static int totalLives = 3;
    private bool hasLives = true;

    public Animator GameOverAnimator;

    void Update()
    {
        if (!hasLives)
        {
            return;
        }

        lives.text = "Lives: " +  totalLives.ToString("0");

        if (totalLives == 0)
        {
            hasLives = false;
            Time.timeScale = 0; // freeze the game
            RestartGame();
        }
    }

    void RestartGame()
    {
        if (GameOverAnimator != null)
        {
            totalLives = 3;
            Debug.Log("Restarting...");
            GameOverAnimator.SetBool("Display", true);
        }
    }
}
