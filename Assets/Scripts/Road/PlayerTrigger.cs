using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public RoadSpawner _roadSpawner;

    // ����� �������� �������� ����� ������� ������, ���������� ����� ������ ������
    private void OnTriggerEnter(Collider other)
    {
        _roadSpawner.Spawn();
        Debug.Log(other.name);
    }
}
