using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile = null;

    private GameObject projectileSpawnPoint = null;
    private string bodyChildStringReference = "Body";
    private string projectileSpawnPointChildStringReference = "Projectile Spawn Point";

    void Start()
    {
        GameObject body = transform.Find(bodyChildStringReference).gameObject;
        projectileSpawnPoint = body.transform.Find(projectileSpawnPointChildStringReference).gameObject;
    }

    public void Fire()
    {
        Instantiate(projectile, projectileSpawnPoint.transform.position, projectileSpawnPoint.transform.rotation);
    }
}
