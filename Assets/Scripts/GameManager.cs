using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : SingletonBehaviour<GameManager>
{
    [SerializeField] private string firstScene;
    [SerializeField] private UnityEvent OnNewGame;
    [SerializeField] private UnityEvent OnEndGame;
    [SerializeField] private Image[] Health;
    [SerializeField] private Image filledHeart;
    [SerializeField] private Image emptyHeart;
    [SerializeField] private int numberOfHeart;

    private GameObject lastCheckpoint;

/*    public void Start()
    {
        StartNewGame();
    }
Il faut ajouter dans le build pour que ça fonctionne (à faire à la fin )
 */
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
        fillHeart();

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

    public void NewCheckpoint(GameObject checkpoint) {
        lastCheckpoint = checkpoint;
    }

    public void RestartToCheckpoint(GameObject player) {
        player.transform.position = lastCheckpoint.transform.position;
    }
    public void TakeDamageEmptyHeart(int damage)
    {
        for (int i = 0; i < damage; i++) {
            Debug.Log("Coeur perdu");
            Health[numberOfHeart - 1].sprite = emptyHeart.sprite;
            numberOfHeart--;
        }

    }

    private void fillHeart() {
        numberOfHeart = 3;
        for (int i = 0; i < numberOfHeart; i++)
        {
            Health[i].sprite = filledHeart.sprite;
        }
    }
}