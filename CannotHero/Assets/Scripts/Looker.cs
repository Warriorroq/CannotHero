using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looker : MonoBehaviour
{
    [SerializeField] private Transform cannon;
    [SerializeField] private Transform rotater;
    void Update()
    {
        transform.LookAt(getMousePosInWorld());
        cannon.eulerAngles = GetCannonAngle();
        rotater.eulerAngles = GetRotaterAngle();
    }
    private Vector3 GetCannonAngle()
        => new Vector3(transform.eulerAngles.x, 
            cannon.eulerAngles.y, 
            cannon.eulerAngles.z);
    private Vector3 GetRotaterAngle()
        => new Vector3(rotater.eulerAngles.x,
            transform.eulerAngles.y,
            rotater.eulerAngles.z);
    private Vector3 getMousePosInWorld()
    {
        var mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        var mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        mousePos3D.z = 0;
        return mousePos3D;
    }
}
