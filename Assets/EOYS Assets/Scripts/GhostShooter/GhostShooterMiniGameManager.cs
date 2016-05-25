using UnityEngine;

public class GhostShooterMiniGameManager : MinigameManager
{
    public GameTimer gameTimer;
    public ScoreKeeper scoreKeeper;
    public SpawnEnemies spawner;
    public GameObject hud;

    public override void GamePause()
    {
        gameTimer.StopTimer();
        hud.SetActive(false);
    }

    public override void GameReset()
    {
        gameTimer.ResetTimer();
        scoreKeeper.Reset();
        spawner.Reset();
        hud.SetActive(false);
    }

    public override void GameResume()
    {
        gameTimer.StartTimer();
        hud.SetActive(true);
    }

    public override void GameStart()
    {
        gameTimer.StartTimer();
        hud.SetActive(true);
    }

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameTimer.GameTimeLeft <= 0)
        {
            spawner.Reset();
            ShowEndGameScreen();
        }
    }

    private void ShowEndGameScreen()
    {
    }
}