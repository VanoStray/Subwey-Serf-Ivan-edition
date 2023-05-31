using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject Interface;
    public PlayerMovement Player;
    public VerticalMovement Capsule;
    public bool _isPause = false;


    public void Pause()
    {
        Interface.SetActive(false);
        pauseMenu.SetActive(true);
        _isPause = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        _isPause = false;
        Interface.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
