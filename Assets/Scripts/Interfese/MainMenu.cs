using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject SettingsMenu;
    public GameObject AdditionalInformationMenu;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ToSettingsMenu()
    {
        SettingsMenu.SetActive(true);
        StartMenu.SetActive(false);
        AdditionalInformationMenu.SetActive(false);
    }
    public void ToContactMenu()
    {
        AdditionalInformationMenu.SetActive(true);
        SettingsMenu.SetActive(false);
        StartMenu.SetActive(false);
    }

    public void ToStartMenu()
    {
        StartMenu.SetActive(true);
        AdditionalInformationMenu.SetActive(false);
        SettingsMenu.SetActive(false);
    }
}
