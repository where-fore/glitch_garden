using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private string startMenuSceneString = "Start Menu";
    private string startAgainMenuSceneString = "Game Over Screen";
    private float timeBeforeLoadingStartMenu = 3f;

    private int currentSceneIndex = 0;
    
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        if (currentSceneIndex == 0)
        {
            StartCoroutine(DelayThenLoadSceneCoroutine(timeBeforeLoadingStartMenu, startMenuSceneString));
        }
    }
    
    public void LoadGameOverScreen(float delay)
    {
        StartCoroutine(DelayThenLoadSceneCoroutine(delay, startAgainMenuSceneString));
    }

    public void LoadNextLevel(float delay)
    {
        StartCoroutine(DelayThenLoadNextSceneCoroutine(delay));
    }


    private IEnumerator DelayThenLoadNextSceneCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator DelayThenLoadSceneCoroutine(float delay, string sceneToLoadStringReference)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(sceneToLoadStringReference);
    }
}
