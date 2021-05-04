using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _maxPeriod = 10f;
    [SerializeField] private float _minPeriod = 2f;
    [SerializeField] private GameObject _targetPrefab;
    private Transform _spawnPosition;
    private float _period;
    private void Start()
    {
        _maxPeriod = FileReader.ReadParam("MaxPeriod");
        _minPeriod = FileReader.ReadParam("MinPeriod");
        _spawnPosition = transform.GetChild(0);
        _period = Random.Range(_minPeriod, _maxPeriod);
        InvokeRepeating(nameof(CreateTarget), _period, _period);
    }
    private void CreateTarget()
    {
        Instantiate(_targetPrefab, _spawnPosition.position, _targetPrefab.transform.rotation);
    }
}
