using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CannonShootAbility : MonoBehaviour
{

    [SerializeField] private float _bulletForce = 100f;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPosition;
    public event Action Shoot;
    void Start()
    {
        _bulletForce = FileReader.ReadParam("BulletForce");
        Shoot += CreateBullet;
    }    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot?.Invoke();
        }
    }
    private void CreateBullet()
    {
        var bullet = Instantiate(_bulletPrefab, _bulletSpawnPosition.position, _bulletSpawnPosition.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * _bulletForce);
    }
}
