using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CannonShootAbility : MonoBehaviour
{

    [SerializeField] private float bulletForce = 100f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPosition;
    public event Action Shoot;
    void Start()
    {
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
        var bullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletForce);
    }
}
