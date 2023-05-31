using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Text CoinsOfInterface;
    public Text CoinsOfEndGame;
    public int _playerCoins;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            _playerCoins++;
            CoinsOfInterface.text = "Монет: " + _playerCoins;
            CoinsOfEndGame.text = "Монет: " + _playerCoins;
        }
    }
}
