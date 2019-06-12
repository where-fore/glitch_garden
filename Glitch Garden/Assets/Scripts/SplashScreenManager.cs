using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenManager : MonoBehaviour
{
    private float delayBeforeLoadingMainMenu = 3f;
    void Start()
    {
        FindObjectOfType<SceneLoader>().LoadMainMenu(delayBeforeLoadingMainMenu);
    }

}
