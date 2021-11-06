using System;
using UnityEngine;

public class GameManagerProxy : MonoBehaviour, IGameManager
{
    public void Quit()
    {
        GameManager.instance.Quit();
    }

    public void StartNewGame()
    {
        GameManager.instance.StartNewGame();
    }

    public void SwitchScene(string sceneToLoad)
    {
        GameManager.instance.StartSwitchSceneCoroutine(sceneToLoad);
    }

    public void EndGame()
    {
        GameManager.instance.EndGame();
    }

    public void NewCheckpoint(GameObject checkpoint)
    {
        GameManager.instance.NewCheckpoint(checkpoint);
    }

    public void RestartToCheckpoint(GameObject player)
    {
        GameManager.instance.RestartToCheckpoint(player);
    }

    public void TakeDamageEmptyHeart(int damage) {
        GameManager.instance.TakeDamageEmptyHeart(damage);
    }

    public void LooseOneSwordCharge() {
        GameManager.instance.LooseOneSwordCharge();
    }

    public void addOneEnemyKill() {
        GameManager.instance.addOneEnemyKill();
    }

    public void loadCreditScreen() {
        GameManager.instance.loadCreditScreen();
    }

    public void switchScreenOrPacific(string sceneToLoad) {
        GameManager.instance.switchScreenOrPacific(sceneToLoad);
    }
}