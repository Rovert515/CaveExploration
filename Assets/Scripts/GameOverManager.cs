using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    private GameObject gameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu = this.gameObject;
        gameOverMenu.SetActive(false);
    }



    /*// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            OpenGameOverMenu();
        }
    }

    public void OpenGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }*/


    // Restarts the current scene

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
        UnityEditor.EditorApplication.isPlaying = false;

        Application.Quit();

    }
}
