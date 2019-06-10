using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private bool timerFinished = false;
    private bool levelFinished = false;

    private AttackerSpawner[] mySpawners = null;

    private void Start()
    {
        mySpawners = FindObjectsOfType<AttackerSpawner>();
    }

    private void Update()
    {
        if (!levelFinished && timerFinished && NoAttackersLeft()) // this may cause performance issues
        {
            levelFinished = true;
            Debug.Log("Next Level!!!!!");
        }
    }
    public void LevelTimerFinished()
    {
        timerFinished = true;
        StopSpawning();
    }

    private void StopSpawning()
    {
        foreach (AttackerSpawner spawner in mySpawners)
        {
            spawner.StopSpawning();
        }
    }

    private bool NoAttackersLeft()
    {
        int numOfSpawners = 0;
        int numOfSpawnersWithZeroAttackers = 0;
        foreach (AttackerSpawner spawner in mySpawners)
        {
            numOfSpawners++;

            if (!spawner.IsSpawning() && spawner.GetAttackersCount() <= 0)
            {
                numOfSpawnersWithZeroAttackers++;
            }
        }
        

        if (numOfSpawnersWithZeroAttackers == numOfSpawners)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
