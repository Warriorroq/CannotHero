using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float maxPeriod = 10f;
    [SerializeField] private float minPeriod = 2f;
    [SerializeField] private GameObject targetPrefab;
    private Transform spawnPosition;
    private float period;
    private void Start()
    {
        spawnPosition = transform.GetChild(0);
        period = Random.Range(minPeriod, maxPeriod);
        InvokeRepeating(nameof(CreateTarget), period, period);
    }
    private void CreateTarget()
    {
        Instantiate(targetPrefab, spawnPosition.position, targetPrefab.transform.rotation);
    }
}
