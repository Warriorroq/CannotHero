using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float _speed = 8f;
    private void Start()
    {
        _speed = FileReader.ReadParam("Speed");
        var scale = FileReader.ReadParam("Scale");
        transform.localScale = new Vector3(scale, scale, scale);
    }
    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime,0,0);
    }
}
