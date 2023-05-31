using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenedger : MonoBehaviour
{
    public float _nextVolume = 0.2f;
    public float _defultVolume = 0.6f;
    public AudioSource Music;
    public GameOver Capsule;
    public PauseMenu Canvas;
    public GameObject JumpAudio;
    public GameObject SlideAudio;
    public GameObject CoinAudio;
    public VerticalMovement CapsuleVM;

    private void Start()
    {
        CoinAudio.SetActive(false);
        JumpAudio.gameObject.SetActive(false);
        SlideAudio.gameObject.SetActive(false);
    }

    private void Update()
    {
        CheckVerticalMovementAudio();
        CheckMusic();
    }
    public void CheckMusic()
    {
        // ���� ���� ����� � ����� �� ��������, �� ������ �� ����������� ���������
        if(!Canvas._isPause && !Capsule._gameOver)
        {
            Music.volume = _defultVolume;
        }
        // ����� ��� ���� ����
        else
        {
            Music.volume = _nextVolume;
        }
    }
    public void CheckVerticalMovementAudio()
    {
        // ���� ������ � ����������
        if(CapsuleVM._canJump)
        {
            JumpAudio.SetActive(false);
            JumpAudio.SetActive(true);
        }
        if(CapsuleVM._canSlide)
        {
            SlideAudio.SetActive(false);
            SlideAudio.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // ���� �����
        if (other.tag == "Coin")
        {
            CoinAudio.SetActive(false);
            CoinAudio.SetActive(true);
        }
    }
}
