using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public PauseMenu Canvas;
    public PlayerMovement Player;
    public VerticalMovement Capsule;
    public GameObject Interface;
    public GameObject GameOverInterfece;
    public float _collisionDelta = 1.0f;
    public bool _gameOver;

    private void Start()
    {
        _gameOver = false;
        Interface.SetActive(true);
        GameOverInterfece.SetActive(false);
    }

    private void Update()
    {
        GameOverIntrfece();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "block")
        {
            _gameOver = true;
        }
    }

    private void GameOverIntrfece()
    {
        if (_gameOver)
        {
            Interface.SetActive(false);
            GameOverInterfece.SetActive(true);
            Player.PlayerDontMovement();
        }
        else
        {
            Interface.SetActive(true);
            GameOverInterfece.SetActive(false);
            Player.PlayerCanMovement();
        }
    }

    public void RecetGame()
    {
        Player.ResetPosition();
        _gameOver = false;
        Canvas.Resume();
    }
}
