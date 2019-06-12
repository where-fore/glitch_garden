using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private string startMenuSceneString = "Start Menu";
    private string firstLevelSceneString = "Level 1";

    private void Awake()
    {
        Time.timeScale = 1;
    }

    public void LoadNextLevel(float delay)
    {
        StartCoroutine(DelayThenLoadNextSceneCoroutine(delay));
    }

    public void LoadMainMenu(float delay)
    {
        StartCoroutine(DelayThenLoadSceneCoroutine(delay, startMenuSceneString));
    }


    public void LoadFirstLevel(float delay)
    {
        StartCoroutine(DelayThenLoadSceneCoroutine(delay, firstLevelSceneString));
    }

    public void QuitGame(float delay)
    {
        StartCoroutine(DelayThenQuitGame(delay));
    }

    public void RestartLevel(float delay)
    {
        StartCoroutine(DelayThenLoadSceneCoroutine(delay, SceneManager.GetActiveScene().name));
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

    private IEnumerator DelayThenQuitGame(float delay)
    {
        yield return new WaitForSeconds(delay);

        Application.Quit();
    }

}
