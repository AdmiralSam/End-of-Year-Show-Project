﻿using UnityEngine;

public class GhostShooterMiniGameManager : MinigameManager
{
    public DisplayGameResults Display;
    public GameTimer gameTimer;
    public GameObject hud;
    public Player player;
    public ScoreKeeper scoreKeeper;
    public SpawnEnemies spawner;
    public WaitTimeAfterGame WaitAfterGame;
    public WaitTimeBeforeGame WaitBeforeGame;
    private GameState result;
    public static bool GameRunning { private set; get; }

    public override void GamePause()
    {
        gameTimer.StopTimer();
        hud.SetActive(false);
        GameRunning = false;
        spawner.StopSpawningEnemies();
    }

    public override void GameReset()
    {
        gameTimer.ResetTimer();
        scoreKeeper.Reset();
        spawner.Reset();
        hud.SetActive(false);

        Display.Reset();
        WaitAfterGame.ResetWait();
        WaitBeforeGame.ResetWait();
        spawner.StopSpawningEnemies();
        GameRunning = false;
    }

    public override void GameResume()
    {
        gameTimer.StartTimer();
        hud.SetActive(true);
        spawner.StartSpawningEnemies();
        GameRunning = true;
    }

    public override void GameStart()
    {
        WaitBeforeGame.GetComponent<UIOpenCloseAnimator>().Open();
        WaitBeforeGame.StartCountDown();
        spawner.StopSpawningEnemies();

        //gameTimer.StartTimer();
        hud.SetActive(true);
    }

    private void GameEnded(bool won)
    {
        if (GameRunning)
        {
            GameRunning = false;
            spawner.Reset();
            Display.ShowGameResult(won);
            gameTimer.StopTimer();
            result = won ? GameState.Won : GameState.Lost;
            WaitAfterGame.StartCountDown();
        }
    }

    // Use this for initialization
    private void Start()
    {
        WaitBeforeGame.Listener = WaitFinished;
        WaitAfterGame.Listener = WaitAfterFinished;
        gameTimer.Listener = () => GameEnded(scoreKeeper.Score >= scoreKeeper.ScoreToWin);
    }

    private void WaitAfterFinished()
    {
        Listener(result);
    }

    private void WaitFinished()
    {
        WaitBeforeGame.GetComponent<UIOpenCloseAnimator>().Close();
        spawner.StartSpawningEnemies();
        gameTimer.StartTimer();
        GameRunning = true;
    }
}