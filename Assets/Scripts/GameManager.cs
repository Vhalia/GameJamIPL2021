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
    [SerializeField] private Image[] Swords;
    [SerializeField] private int numberOfSwords;
    [SerializeField] private UnityEvent creditWarrior;
    [SerializeField] private UnityEvent creditPacific;
    [SerializeField] private UnityEvent onTriggerEndDoor;

    private GameObject lastCheckpoint;
    private int killCounter = 0;

    public void Start()
    {
        StartNewGame();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartNewGame()
    {
        killCounter = 0;
        StartCoroutine(SwitchScene(firstScene, () => OnNewGame?.Invoke()));
    }
    public void StartSwitchSceneCoroutine(string sceneToLoad) {
        StartCoroutine(SwitchScene(sceneToLoad));
    }
    public IEnumerator SwitchScene(string sceneToLoad, Action callback = null)
    {
        fillHeart();
        fillSwords();

        if (SceneManager.sceneCount > 1)
        {
            var currentScene = SceneManager.GetActiveScene().name;
            Debug.Log(currentScene);
            yield return SceneManager.UnloadSceneAsync(currentScene);

        }
        Debug.Log("Load new scene");
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

    public void RestartToCheckpoint(GameObject player) 
    {
        StartCoroutine(RestartToCheckpointDelay(player)); 
    }

    private IEnumerator RestartToCheckpointDelay(GameObject player)
    {
        player.GetComponent<IHealth>()?.TakeDamage(1);
        yield return new WaitForSeconds((float)0.3);

        if (player.GetComponent<IHealth>()?.GetCurrentHealth() > 0)
        {
            player.transform.position = lastCheckpoint.transform.position;
        }
    }
    public void TakeDamageEmptyHeart(int damage)
    {
        for (int i = 0; i < damage; i++) {
            Health[numberOfHeart - 1].sprite = emptyHeart.sprite;
            numberOfHeart--;
        }

    }
    public void LooseOneSwordCharge() {
        Swords[numberOfSwords - 1].enabled = false;
        numberOfSwords--;
    }

    private void fillHeart() {
        numberOfHeart = 3;
        for (int i = 0; i < numberOfHeart; i++)
        {
            Health[i].sprite = filledHeart.sprite;
        }
    }

    private void fillSwords() {
        numberOfSwords = 5;
        for (int i = 0; i < numberOfSwords; i++)
        {
            Swords[i].enabled = true;
        }
    }
    public void addOneEnemyKill() {
        killCounter++;
    }

    public void loadCreditScreen() {

            creditWarrior?.Invoke();
        
    }
    public void switchScreenOrPacific(string sceneToLoad)
    {
        if (killCounter == 0)
        {
            creditPacific?.Invoke();
        }
        else
        {
            StartCoroutine(SwitchScene(sceneToLoad));
        }
    }
}