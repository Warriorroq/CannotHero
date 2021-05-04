using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeObject : MonoBehaviour
{
    [SerializeField] private float _time;
    private void Start()
    {
        Invoke(nameof(Destroy), _time);
    }
    private void Destroy() => Destroy(gameObject);
}
