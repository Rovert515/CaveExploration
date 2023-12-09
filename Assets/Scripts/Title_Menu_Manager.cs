using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_Menu_Manager : MonoBehaviour
{
    private GameObject TitleMenu;
    private GameObject HelpMenu;
    private GameObject SettingsMenu;

    private bool menuOpen;

    // Start is called before the first frame update
    void Start()
    {
        TitleMenu = GameObject.FindWithTag("TitleMenu");
        TitleMenu.SetActive(true);

        HelpMenu = GameObject.FindWithTag("HelpMenu");
        HelpMenu.SetActive(false);

        SettingsMenu = GameObject.FindWithTag("SettingsMenu");
        SettingsMenu.SetActive(false);

        menuOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Cursor.visible = false; // hide the cursor because we're going to be using it to look around
        Cursor.lockState = CursorLockMode.Locked; // lock the cursor because we're going to be using it to look around
        SceneManager.LoadScene(1);
    }

    //Open help menu
    public void OpenHelp()
    {
        menuOpen = true;
        TitleMenu.SetActive(false);
        HelpMenu.SetActive(true);
    }
    public void CloseHelp()
    {
        menuOpen = false;
        HelpMenu.SetActive(false);
        TitleMenu.SetActive(true);
    }

    //Open settings menu
    public void OpenSettings()
    {
        menuOpen = true;
        TitleMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }
    public void CloseSettings()
    {
        menuOpen = false;
        SettingsMenu.SetActive(false);
        TitleMenu.SetActive(true);
    }

    //Quit game
    public void QuitGame()
    {
        Application.Quit();
    }
}
