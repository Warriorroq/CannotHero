using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    private void Update()
    {
        transform.Translate(speed * Time.deltaTime,0,0);
    }
}
