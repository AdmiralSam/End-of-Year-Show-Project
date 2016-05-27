﻿using UnityEngine;
using UnityEngine.UI;

public class PongGameMiniGameManager : MinigameManager
{
    public static bool GameRunning { private set; get; }

    public Text Debug;

    public GameTimer PongGameTimer;
    public WaitTimeBeforeGame WaitBeforeGame;
	public WaitTimeAfterGame WaitAfterGame;
    public GameObject AllGameObjectsContainer;
    public BallController PongBallController;
    public DisplayGameResult Display;

	private GameState result;

    public override void GamePause()
    {
        GameRunning = false;
        PongGameTimer.StopTimer();
    }

    public override void GameReset()
    {
        GameRunning = false;
        PongGameTimer.ResetTimer();
        WaitBeforeGame.ResetWait();
		WaitAfterGame.ResetWait();
        PongBallController.ResetBall();
    }

    public override void GameResume()
    {
        GameRunning = true;
        PongGameTimer.StartTimer();
    }

    public override void GameStart()
    {
        WaitBeforeGame.gameObject.SetActive(true);
        WaitBeforeGame.StartCountDown();
        GameRunning = false;
        AllGameObjectsContainer.SetActive(true);
        PongBallController.gameObject.SetActive(true);
    }

    private void Start()
    {
        WaitBeforeGame.Listener = WaitFinished;
		PongGameTimer.Listener = () => GameEnded(true);
		PongBallController.Listener = () => GameEnded(false);
		WaitAfterGame.Listener = WaitAfterFinished;
    }

    private void WaitFinished()
    {
        WaitBeforeGame.gameObject.SetActive(false);
        GameRunning = true;
        PongGameTimer.StartTimer();
        PongBallController.StartBallMovement();
    }

	private void WaitAfterFinished()
	{
		Listener(result);
	}

	private void GameEnded(bool won) {
		if (GameRunning)
		{
			Display.PanelActivation(true, won);
			GameRunning = false;
			PongGameTimer.StopTimer();
			AllGameObjectsContainer.gameObject.SetActive(false);
			result = won ? GameState.Won : GameState.Lost;
			WaitAfterGame.StartCountDown();
		}
	}
}