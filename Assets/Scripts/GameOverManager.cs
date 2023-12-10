using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Menu manager script for the game over menu
public class GameOverManager : MonoBehaviour
{
    private GameObject gameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu = this.gameObject;
        gameOverMenu.SetActive(false);
    }

    public void OpenMenu()
    {
        Cursor.visible = true; // free up the cursor so that we can navigate the game over menu
        Cursor.lockState = CursorLockMode.None;
        gameObject.SetActive(true); // open the game over menu
    }

    public void RestartScene()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    // Quits the game
    public void QuitGame()
    {
        Application.Quit();

    }
}
