using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looker : MonoBehaviour
{
    [SerializeField] private GameObject cannon;
    [SerializeField] private GameObject rotater;
    void Update()
    {
        transform.LookAt(getMousePosInWorld());
        cannon.transform.eulerAngles = GetCannonAngle();
        rotater.transform.eulerAngles = GetRotaterAngle();
    }
    private Vector3 GetCannonAngle()
        => new Vector3(transform.eulerAngles.x, 
            cannon.transform.eulerAngles.y, 
            cannon.transform.eulerAngles.z);
    private Vector3 GetRotaterAngle()
        => new Vector3(rotater.transform.eulerAngles.x,
            transform.eulerAngles.y,
            rotater.transform.eulerAngles.z);
    private Vector3 getMousePosInWorld()
    {
        var mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        var mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        mousePos3D.z = 0;
        return mousePos3D;
    }
}
