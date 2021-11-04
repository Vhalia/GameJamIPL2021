using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    [SerializeField] private string firstScene;
    [SerializeField] private UnityEvent OnNewGame;
    [SerializeField] private UnityEvent OnEndGame;

    public void Quit()
    {
        Application.Quit();
    }

    public void StartNewGame()
    {
        StartCoroutine(SwitchScene(firstScene, () => OnNewGame?.Invoke()));
    }

    public IEnumerator SwitchScene(string sceneToLoad, Action callback = null)
    {

        if (SceneManager.sceneCount > 1)
        {
            var currentScene = SceneManager.GetActiveScene().name;
            yield return SceneManager.UnloadSceneAsync(currentScene);
        }
        yield return SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToLoad));
        callback?.Invoke();
    }

    public void EndGame()
    {
        OnEndGame?.Invoke();
    }
}