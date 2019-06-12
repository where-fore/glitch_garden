using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject levelCompleteCanvas = null;
    [SerializeField] GameObject levelLostCanvas = null;
    private float delayBeforeLoseGameScreen = 3.5f;
    private bool timerFinished = false;
    private bool levelFinished = false;
    private bool levelLost = false;
    private float delayBeforeNextLevel = 5f;
    private AttackerSpawner[] mySpawners = null;
    private SceneLoader sceneLoaderObject = null;

    private void Start()
    {
        mySpawners = FindObjectsOfType<AttackerSpawner>();
        sceneLoaderObject = FindObjectOfType<SceneLoader>();
    }

    private void Update()
    {
        if (!levelFinished && timerFinished && NoAttackersLeft()) // this may cause performance issues
        {
            levelFinished = true;
            FinishLevel();
        }
    }

    private void FinishLevel()
    {
        levelCompleteCanvas.SetActive(true);
        sceneLoaderObject.LoadNextLevel(delayBeforeNextLevel);
    }

    public void LoseLevel(Vector3 killer)
    {
        if (levelLost) {return;}
        levelLost = true;

        FindObjectOfType<LosingZoom>().Zoom(killer);

        levelLostCanvas.SetActive(true);
        StartCoroutine(SecondStageLosing(delayBeforeLoseGameScreen));
    }

    private IEnumerator SecondStageLosing(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        Time.timeScale = 0;
        FindObjectOfType<LevelLostCanvasBehaviour>().BringUpButtons();
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
