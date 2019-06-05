using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile = null;

    private GameObject projectileSpawnPoint = null;
    private string bodyChildStringReference = "Body";
    private string projectileSpawnPointChildStringReference = "Projectile Spawn Point";

    private List<AttackerSpawner> mySpawners = new List<AttackerSpawner>();

    void Start()
    {
        GameObject body = transform.Find(bodyChildStringReference).gameObject;
        projectileSpawnPoint = body.transform.Find(projectileSpawnPointChildStringReference).gameObject;

        FindMySpawners();
    }

    private void FindMySpawners()
    {
        AttackerSpawner[] allSpawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in allSpawners)
        {
            bool isInLane = (Mathf.Abs(spawner.transform.position.y - this.transform.position.y) <= Mathf.Epsilon);

            if(isInLane)
            {
                mySpawners.Add(spawner);
            }
        }
    }

    private bool isThereAnAttackerInLane()
    {
        foreach (AttackerSpawner spawner in mySpawners)
        {
            if (spawner.transform.childCount > 0)
            {
                return true;
            }
        }
        // if you got this far...
        return false;
    }

    private void Update()
    {
        if (isThereAnAttackerInLane())
        {
            Debug.Log("HOSTILE DETECTED");
        }
        else{
            Debug.Log("Standby...");
        }
    }

    public void Fire()
    {
        Instantiate(projectile, projectileSpawnPoint.transform.position, projectileSpawnPoint.transform.rotation);
    }
}
