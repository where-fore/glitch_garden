using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    [Tooltip("Level timer in seconds.")][SerializeField] private float levelTime = 10f;

    private Slider mySlider = null;
    private LevelManager levelManagerObject = null;

    private bool managerInformedLevelFinished = false;

    private void Start()
    {
        mySlider = GetComponent<Slider>();
        levelManagerObject = FindObjectOfType<LevelManager>();
    }

    void Update()
    {
       mySlider.value = (Time.timeSinceLevelLoad / levelTime) * 100;

        if (!managerInformedLevelFinished)
        {
            bool levelFinished = Time.timeSinceLevelLoad > levelTime;
            if (levelFinished)
            {
                TellManagerLevelFinished();
                managerInformedLevelFinished = true;
            }
        }
      
    }

    private void TellManagerLevelFinished()
    {
        levelManagerObject.LevelTimerFinished();
    }
}
