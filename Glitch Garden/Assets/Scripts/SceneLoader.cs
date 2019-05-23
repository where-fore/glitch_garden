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
            StartCoroutine(WaitThenLoadStartMenu());
        }
    }

    private IEnumerator WaitThenLoadStartMenu()
    {
        yield return new WaitForSeconds(timeBeforeLoadingStartMenu);

        LoadStartMenu();
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(startMenuSceneString);
    }
}
