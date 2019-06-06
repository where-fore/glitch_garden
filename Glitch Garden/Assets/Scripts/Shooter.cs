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

    private Animator myAnimatorComponent = null;
    private string isAttackingAnimationParameterStringReference = "ShouldAttack";

    void Start()
    {
        GameObject body = transform.Find(bodyChildStringReference).gameObject;
        projectileSpawnPoint = body.transform.Find(projectileSpawnPointChildStringReference).gameObject;

        myAnimatorComponent = GetComponent<Animator>();

        FindMySpawners();
    }

    private void Update()
    {
        if (IsThereAnAttackerInLane())
        {
            myAnimatorComponent.SetBool(isAttackingAnimationParameterStringReference, true);
        }
        else
        {
            myAnimatorComponent.SetBool(isAttackingAnimationParameterStringReference, false);
        }
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

    private bool IsThereAnAttackerInLane()
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

    public void Fire()
    {
        Instantiate(projectile, projectileSpawnPoint.transform.position, projectileSpawnPoint.transform.rotation);
    }
}
