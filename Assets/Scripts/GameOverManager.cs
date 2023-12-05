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
        gameOverMenu = GameObject.FindWithTag("GameOverMenu");
        gameOverMenu.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {

    }

    public void OpenGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }


        // Restarts the current scene
        public void RestartScene()
    {
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
