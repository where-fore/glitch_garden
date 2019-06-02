using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile = null;

    private GameObject projectileSpawnPoint = null;
    private string projectileSpawnPointStringReference = "Projectile Spawn Point";

    void Start()
    {
        projectileSpawnPoint = transform.Find(projectileSpawnPointStringReference).gameObject;
    }

    public void Fire()
    {
        Instantiate(projectile, projectileSpawnPoint.transform.position, projectileSpawnPoint.transform.rotation);
    }
}
