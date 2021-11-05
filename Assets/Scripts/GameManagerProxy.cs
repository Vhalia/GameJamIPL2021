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
        StartCoroutine(GameManager.instance.SwitchScene(sceneToLoad));
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
}