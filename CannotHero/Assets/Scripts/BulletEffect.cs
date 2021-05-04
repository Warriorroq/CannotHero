using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffect : MonoBehaviour
{
    [SerializeField] private GameObject _particle;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Target>(out var target))
        {
            Instantiate(_particle, transform.position, Quaternion.identity);
            Destroy(target.gameObject);
            Destroy(gameObject);
        }
    }
}
