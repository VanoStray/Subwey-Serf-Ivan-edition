using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public RoadSpawner _roadSpawner;

    // Когда персонаж проходит через триггер дороги, вызывается метод спавна дороги
    private void OnTriggerEnter(Collider other)
    {
        _roadSpawner.Spawn();
        Debug.Log(other.name);
    }
}
