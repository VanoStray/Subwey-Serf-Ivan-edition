using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public PlayerMovement Player;
    public Text Record;

    private void Update()
    {
        Record.text = "–екорд: " + (int)Player.PlayerPositionZ() + "м";
    }

}
