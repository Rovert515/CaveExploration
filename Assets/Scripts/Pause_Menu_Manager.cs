using System.Collections;
using System.Collections.Generic;
using Assets.Pixelation.Example.Scripts;
using UnityEngine;

public class Pause_Menu_Manager : MonoBehaviour
{

    private GameObject PauseMenu;
    private GameObject Player;

    private Assets.Pixelation.Scripts.Chunky chunkyScript;

    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu = GameObject.FindWithTag("PauseMenu");
        PauseMenu.SetActive(false);
        Player = GameObject.FindWithTag("Player");
        chunkyScript = Player.GetComponentInChildren<Assets.Pixelation.Scripts.Chunky>(true);
        chunkyScript.enabled = false;

        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            isPaused = !isPaused;
        }

        if (isPaused == true)
        {
            PauseGame();
            PauseMenu.SetActive(true);
            chunkyScript.enabled = true;

        }
        else //isPaused = false
        {
            ResumeGame();
            PauseMenu.SetActive(false);
            chunkyScript.enabled = false;
        }
    }

    //Pause game
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
