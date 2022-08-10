using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //next level index
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //restart level
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("GameEnd");
    }
}
