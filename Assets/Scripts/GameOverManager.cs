using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    private GameObject gameOverMenu;

    //FIXME disable MouseLook when gameover happens
    public MouseLook MouseLook;

    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu = GameObject.FindWithTag("GameOverMenu");
        gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // add game over logic here

        // For testing
        if (Input.GetKeyDown(KeyCode.M))
        {
            gameOverMenu.SetActive(true);
            PauseGame();
        
        }

        
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            QuitGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        // isPaused = true;

        if (MouseLook != null)
        {
            MouseLook.enabled = false;
        }
        

    }

    // Restarts the current scene
    void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    // Quits the game
    void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;

        Application.Quit();

    }
}
