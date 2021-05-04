using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonEffect : MonoBehaviour
{
    [SerializeField]private GameObject _particle;
    private void Start()
    {
        FindObjectOfType<CannonShootAbility>().Shoot += CreateParticles;
    }
    private void CreateParticles()
        =>Instantiate(_particle, transform.position, Quaternion.identity);
    
}
