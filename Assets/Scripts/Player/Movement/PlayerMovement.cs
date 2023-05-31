using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public VerticalMovement Capsule;
    public float _speed = 10.0f;
    public float _speedGorizontal = 8.0f;
    public int _nextPlayerRowPosition = 2;
    public bool _playerMovement;
    private int _playerRowPosition = 2;
    private float _indent = 2.0f;

    private void Start()
    {
        _playerMovement = true;
    }

    private void Update()
    {
        MovementForward();
        CheckMovement();
        CheckRowPosition();
    }

    private void CheckRowPosition()
    {
        // ���� ����� � ������, �� �� � 2 ����
        if (transform.position.x == 0)
        {
            _playerRowPosition = 2;
        }
        //���� ����� �����, �� �� � 1 ����
        if (transform.position.x == -(_indent))
        {
            _playerRowPosition = 1;
        }
        // ���� ����� ������, �� �� � 3 ����
        if (transform.position.x == _indent)
        {
            _playerRowPosition = 3;
        }
    }
    private void MovementForward()
    {
        // ���������� �������� �� ������
        if (_playerMovement)
        {
            transform.Translate(0, 0, _speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(0, 0, 0);
        }
    }

    private void CheckMovement()
    {
        // ����� ������� �������� �� ����, �� ��������� ��������� �������� � �������� ���������
        switch (_playerRowPosition)
        {
            case 1:
                if (_nextPlayerRowPosition == 2)
                    MovementToRow2();
                break;
            case 2:
                if (_nextPlayerRowPosition == 1)
                    MovementToRow1();
                if (_nextPlayerRowPosition == 3)
                    MovementToRow3();
                break;
            case 3:
                if (_nextPlayerRowPosition == 2)
                    MovementToRow2();
                break;
        }

        // ���� ����� �� ��������� �����, �� �� ��������������� �������
        if (transform.position.x > _indent)
        {
            transform.position = new Vector3(2, 0, transform.position.z);
        }
        if (transform.position.x < -(_indent))
        {
            transform.position = new Vector3(-2, 0, transform.position.z);
        }
    }

    private void MovementToRow1()
    {
        // ������������� ����������� �������� �� ��������� ������� ������
        int destionation = 0;
        switch (_playerRowPosition)
        {
            case 1:
                destionation = 0;
                break;
            case 2:
                destionation = -1;
                break;
            case 3:
                destionation = -1;
                break;
        }

        // �������� �� �������
        if (transform.position.x > -(_indent) && _playerMovement)
        {
            transform.Translate(_speedGorizontal * Time.deltaTime * destionation, 0, 0);
        }
        // ��������� �������� ��������� ������ � ������ ����
        else
        {
            if (_playerMovement)
            {
                transform.position = new Vector3(-(_indent), 0, transform.position.z);
                _playerRowPosition = 1;
            }
        }
    }
    private void MovementToRow2()
    {
        // ������������� ����������� �������� �� ��������� ������� ������
        int destionation = 0;
        switch (_playerRowPosition)
        {
            case 1:
                destionation = 1;
                break;
            case 2:
                destionation = 0;
                break;
            case 3:
                destionation = -1;
                break;
        }

        // �������� �� �������
        if ((transform.position.x < -0.1 || transform.position.x > 0.1) && _playerMovement)
        {
            transform.Translate(_speedGorizontal * Time.deltaTime * destionation, 0, 0);
        }
        // ��������� �������� ��������� ������ � ������ ����
        else
        {
            if (_playerMovement)
            {
                transform.position = new Vector3(0, 0, transform.position.z);
                _playerRowPosition = 2;
            }
        }
    }
    private void MovementToRow3()
    {
        // ������������� ����������� �������� �� ��������� ������� ������
        int destionation = 0;
        switch (_playerRowPosition)
        {
            case 1:
                destionation = 1;
                break;
            case 2:
                destionation = 1;
                break;
            case 3:
                destionation = 0;
                break;
        }

        // �������� �� �������
        if (transform.position.x < _indent && _playerMovement)
        {
            transform.Translate(_speedGorizontal * Time.deltaTime * destionation, 0, 0);
        }
        // ��������� �������� ��������� ������ � ������ ����
        else
        {
            if (_playerMovement)
            {
                transform.position = new Vector3(_indent, 0, transform.position.z);
                _playerRowPosition = 3;
            }
        }
    }

    // ����������� ������
    public void NextPlayerRowPositionRight()
    {
        if (_nextPlayerRowPosition < 3)
        {
            _nextPlayerRowPosition++;
        }
    }

    // ����������� �����
    public void NextPlayerRowPositionLeft()
    {
        if (_nextPlayerRowPosition > 1)
        {
            _nextPlayerRowPosition--;
        }
    }

    public float PlayerPositionZ()
    {
        return transform.position.z;
    }
    public float PlayerPositionX()
    {
        return transform.position.x;
    }

    // ����� �� ����� ���������
    public void PlayerDontMovement()
    {
        _playerMovement = false;
        Capsule.PlayerDontMovement();
    }

    // ����� ����� ���������
    public void PlayerCanMovement()
    {
        _playerMovement = true;
        Capsule.PlayerCanMovement();
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(0, 0, 0);
        Capsule.ResetPosition();
    }
}
