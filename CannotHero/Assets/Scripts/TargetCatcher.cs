using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TargetCatcher : MonoBehaviour
{
    public event Action<GameObject> missedTarget;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Target>(out var target))
        {
            missedTarget?.Invoke(target.gameObject);
            Destroy(target.gameObject);
        }
    }
}
