using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonEffect : MonoBehaviour
{
    [SerializeField]private GameObject Particles;
    private void Start()
    {
        FindObjectOfType<CannonShootAbility>().Shoot += CreateParticles;
    }
    private void CreateParticles()
        =>Instantiate(Particles, transform.position, Quaternion.identity);
    
}
