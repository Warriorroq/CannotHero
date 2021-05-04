using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeObject : MonoBehaviour
{
    [SerializeField] private float _time;
    private void Start()
    {
        _time = FileReader.ReadParam("BulletLifeTime");
        Invoke(nameof(Destroy), _time);
    }
    private void Destroy() => Destroy(gameObject);
}
