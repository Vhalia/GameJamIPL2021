using UnityEngine;

public interface IGameManager
{
    void Quit();
    void StartNewGame();
    void SwitchScene(string sceneToLoad);
    void EndGame();
    void NewCheckpoint(GameObject checkpoint);
    void RestartToCheckpoint(GameObject player);
    void TakeDamageEmptyHeart(int damage);
    public void LooseOneSwordCharge();
    public void addOneEnemyKill();
    public void loadCreditScreen();
    public void switchScreenOrPacific(string sceneToLoad);
}