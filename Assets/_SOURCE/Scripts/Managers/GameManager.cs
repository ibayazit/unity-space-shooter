using System;

public class GameManager : Singleton<GameManager>
{
    public bool isGamePaused = true;

    public Action<bool> OnGamePaused;

    public void GamePaused(bool isPaused){
        isGamePaused = isPaused;

        OnGamePaused?.Invoke(isGamePaused);
    }
}
