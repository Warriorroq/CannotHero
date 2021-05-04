using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float maxPeriod = 10f;
    [SerializeField] private float minPeriod = 2f;
    [SerializeField] private GameObject prefab;
    private GameObject spawnPosition;
    private float period;
    private void Start()
    {
        spawnPosition = transform.GetChild(0).gameObject;
        period = Random.Range(minPeriod, maxPeriod);
        InvokeRepeating(nameof(CreateTarget), period, period);
    }
    private void CreateTarget()
    {
        Instantiate(prefab, spawnPosition.transform.position, prefab.transform.rotation);
    }
}
