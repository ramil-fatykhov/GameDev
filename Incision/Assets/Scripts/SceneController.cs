using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject panel;

    public void StopGame()
    {
        StoppingTime();
        panel.SetActive(true);
    }

    public void ContinueGame()
    {
        StartingTime();
        panel.SetActive(false);
    }

    public void LoadCurrentScene()
    {
        LoadScene(GetActiveScene().name);
    }

    public void LoadNextScene()
    {
        StartingTime();
        int nextScene = GetActiveScene().buildIndex + 1;

        if (nextScene < GetSceneCountInBuildSettings())
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    public void LoadScene(string name)
    {
        StartingTime();
        SceneManager.LoadScene(name);
    }

    public void LoadNextSceneAfterWaiting()
    {
        StartCoroutine(LoadNextSceneAfterDelay());
    }

    IEnumerator LoadNextSceneAfterDelay()
    {
        yield return new WaitForSeconds(0.5f);
        LoadNextScene();
    }

    public Scene GetActiveScene()
    {
        return SceneManager.GetActiveScene();
    }

    public int GetSceneCountInBuildSettings()
    {
        return SceneManager.sceneCountInBuildSettings;
    }

    public int GetBuildIndexByScenePath(string name)
    {
        return SceneUtility.GetBuildIndexByScenePath(name);
    }

    public void StartingTime()
    {
        Time.timeScale = 1f;
    }

    public void StoppingTime()
    {
        Time.timeScale = 0f;
    }
}
