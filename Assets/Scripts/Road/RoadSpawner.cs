using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    private GameObject _road;
    public List<GameObject> _roads;
    public float _roadLenth;

    private void Start()
    {
        _road = Instantiate(_roads[(Random.Range(0, _roads.Count))], transform.position, Quaternion.identity);
    }

    // �� ����� ������� RoadSpawner ������ ���������� ���� �� prifabs ������
    public void Spawn()
    {
        Vector3 position = new Vector3(0, 0, _road.transform.position.z + _roadLenth);
        _road = Instantiate(_roads[(Random.Range(0, _roads.Count))], position, Quaternion.identity);
    }
}
