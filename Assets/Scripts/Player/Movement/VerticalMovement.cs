using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public float _jumpHelth = 2.0f;
    public float _speedJump = 10.0f;
    public float _speedDown = -15.0f;
    public float _secondOfSlide = 10.0f;
    public bool _canJump;
    public bool _canSlide;

    private bool _isGround;
    private bool _endSlide;
    private bool _playerMovement;
    private float _startJumpPositionY;

    private void OnCollisionEnter()
    {
        // Если персонаж косается земли, то
        _isGround = true;
    }

    private void Start()
    {
        _playerMovement = true;
    }

    private void Update()
    {
        CheckJump();
        CheckSlide();
    }
    public void Jump()
    {
        if (_isGround && _playerMovement)
        {
            _canSlide = false;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 4);
            _startJumpPositionY = transform.position.y;
            _canJump = true;
        }
    }

    public void CheckJump()
    {
        if (_canJump && _playerMovement)
        {
            _isGround = false;
            if ((transform.position.y - _startJumpPositionY) < _jumpHelth)
            {
                transform.Translate(0, _speedJump * Time.deltaTime, 0);
            }
            else
            {
                _canJump = false;
            }
        }
    }

    public void Slide()
    {
        if (_playerMovement)
        {
            _canJump = false;
            _canSlide = true;
            _endSlide = false;
        }
    }

    public void CheckSlide()
    {
        // Игрок опускается вниз пока не коснется земли
        if (!_isGround && _canSlide && _playerMovement)
        {
            transform.Translate(0, _speedDown * Time.deltaTime, 0);
        }
        // Игрок поворачивается до -80 градусов
        else if (_canSlide && _playerMovement)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-90, 0, 0), (_secondOfSlide / 2) * Time.deltaTime);
            if (transform.rotation.x * 130.5 < -80)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-90, 0, 0), Time.deltaTime * Time.deltaTime);
                _canSlide = false;
                _endSlide = true;
            }
        }
        // Игрок поворачивается до 0 градусов
        else if (_endSlide && _playerMovement)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), (_secondOfSlide / 2) * Time.deltaTime);
        }
    }


    public void PlayerDontMovement()
    {
        _playerMovement = false;
    }

    public void PlayerCanMovement()
    {
        _playerMovement = true;
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(0, 1, 0);
    }
}
