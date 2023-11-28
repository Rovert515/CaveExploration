using System.Collections;
using System.Collections.Generic;
using Assets.Pixelation.Example.Scripts;
using UnityEngine;

public class Pause_Menu_Manager : MonoBehaviour
{

    private GameObject PauseMenu;
    private GameObject HelpMenu;
    private GameObject SettingsMenu;
    private GameObject Player;

    private Assets.Pixelation.Scripts.Chunky chunkyScript;

    private bool isPaused;
    private bool menuOpen;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu = GameObject.FindWithTag("PauseMenu");
        PauseMenu.SetActive(false);

        HelpMenu = GameObject.FindWithTag("HelpMenu");
        HelpMenu.SetActive(false);

        SettingsMenu = GameObject.FindWithTag("SettingsMenu");
        SettingsMenu.SetActive(false);

        Player = GameObject.FindWithTag("Player");
        chunkyScript = Player.GetComponentInChildren<Assets.Pixelation.Scripts.Chunky>(true);
        chunkyScript.enabled = false;

        isPaused = false;
        menuOpen = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            if (menuOpen == false)
            {
                SwapPaused();
            }

            if (menuOpen == false)
            {
                if (isPaused == false)
                {
                    ResumeGame();
                }
                else //isPaused true
                {
                    PauseGame();
                }
            }
            
        }
    }

    //Pause game
    public void SwapPaused()
    {
        isPaused = !isPaused;
    }
    void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
        chunkyScript.enabled = true;
        isPaused = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        chunkyScript.enabled = false;
        isPaused = false;
    }

    //Open help menu
    public void OpenHelp()
    {
        menuOpen = true;
        PauseMenu.SetActive(false);
        HelpMenu.SetActive(true);
    }
    public void CloseHelp()
    {
        menuOpen = false;
        HelpMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }

    //Open settings menu
    public void OpenSettings()
    {
        menuOpen = true;
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }
    public void CloseSettings()
    {
        menuOpen = false;
        SettingsMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }

    //Quit game
    public void QuitGame()
    {
        Application.Quit();
    }
}
