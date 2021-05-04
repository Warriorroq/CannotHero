using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looker : MonoBehaviour
{
    [SerializeField] private Transform _cannon;
    [SerializeField] private Transform _rotater;
    void Update()
    {
        transform.LookAt(getMousePosInWorld());
        _cannon.eulerAngles = GetCannonAngle();
        _rotater.eulerAngles = GetRotaterAngle();
    }
    private Vector3 GetCannonAngle()
        => new Vector3(transform.eulerAngles.x, 
            _cannon.eulerAngles.y, 
            _cannon.eulerAngles.z);
    private Vector3 GetRotaterAngle()
        => new Vector3(_rotater.eulerAngles.x,
            transform.eulerAngles.y,
            _rotater.eulerAngles.z);
    private Vector3 getMousePosInWorld()
    {
        var mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        var mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        mousePos3D.z = 1;
        return mousePos3D;
    }
}
