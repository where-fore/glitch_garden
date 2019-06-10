using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private string startMenuSceneString = "Start Menu";
    private float timeBeforeLoadingStartMenu = 3f;

    private int currentSceneIndex = 0;
    
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        if (currentSceneIndex == 0)
        {
            StartCoroutine(DelayThenLoadScene(timeBeforeLoadingStartMenu, startMenuSceneString));
        }
    }
    public void LoadGameOverScreen(float delay)
    {
        StartCoroutine(DelayThenLoadScene(delay, startMenuSceneString));
    }

    private IEnumerator DelayThenLoadScene(float delay, string sceneToLoadStringReference)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(sceneToLoadStringReference);
    }
}
