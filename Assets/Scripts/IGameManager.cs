using System;
using UnityEngine;

public interface IGameManager
{
    void Quit();
    void StartNewGame();
    void SwitchScene(string sceneToLoad);
    void EndGame();
    void NewCheckpoint(GameObject checkpoint);
    void RestartToCheckpoint(GameObject player);
}