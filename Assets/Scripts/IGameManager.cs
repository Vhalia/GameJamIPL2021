using System;

public interface IGameManager
{
    void Quit();
    void StartNewGame();
    void SwitchScene(string sceneToLoad);

    void EndGame();
}