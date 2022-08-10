using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//controls score, displays score
//controls level endings

public class GameManager : MonoBehaviour
{
    public static int totalScore;
    public int scoreGoal;
    public bool isPaused;

    public Animator LevelPassedAnimator;
    public Animator LevelFailedAnimator;
    public Animator GamePassedAnimator;

    void Start()
    {
        totalScore = 0;
    }

    void Update()
    {
        //score goal achieved!
        if (totalScore == scoreGoal && Timer.currentTime > 0 && LifeCount.totalLives > 0 && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Level3"))
        {
            Time.timeScale = 0; // freeze the game
            EndLevel(); //transition to next level
        }

        //score goal achieved at end game!
        if (totalScore == scoreGoal && Timer.currentTime > 0 && LifeCount.totalLives > 0 && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level3"))
        {
            Time.timeScale = 0; // freeze the game
            EndGame(); //transition to next level
        }

        // score goal not met, timer ran out
        if (totalScore < scoreGoal && Timer.currentTime == 0 && LifeCount.totalLives > 0)
        {
            Time.timeScale = 0; // freeze the game
            RestartLevel();
        }
    }

    void OnGUI()
    {
        if (isPaused)
        {
            return;
        }

        GUI.skin.box.fontSize = 30;
        GUI.Box(new Rect(100, 50, 200, 50), "Score: " + totalScore.ToString());
    }

    void EndLevel()
    {
        if (LevelPassedAnimator != null)
        {
            LevelPassedAnimator.SetBool("Display", true);
        }
    }

    void RestartLevel()
    {
        if (LevelFailedAnimator != null)
        {
            LevelFailedAnimator.SetBool("Display", true);
        }
    }

    void EndGame()
    {
        if (GamePassedAnimator != null)
        {
            GamePassedAnimator.SetBool("GameComplete", true);
        }
    }
}