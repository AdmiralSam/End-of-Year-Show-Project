using UnityEngine;
using System.Collections;

public class DodgeGhostsMiniGameManager : MinigameManager {

	public GameTimer gameTimer;
	public WaitTimeAfterGame WaitAfterGame;
	public WaitTimeBeforeGame WaitBeforeGame;
	public DisplayGameResults Display;
	public SpawnRandomEnemies spawner;

	public DestroyOnCollision playerDestroyer;

	private GameState result;
	public static bool GameRunning { private set; get; }


	public override void GamePause()
	{
		gameTimer.StopTimer ();
		GameRunning = false;
		spawner.StopSpawningEnemies ();
		playerDestroyer.gameObject.SetActive (false);
	}

	public override void GameReset()
	{
		gameTimer.ResetTimer ();
		GameRunning = false;
		Display.Reset ();
		WaitBeforeGame.ResetWait ();
		WaitAfterGame.ResetWait ();
		spawner.StopSpawningEnemies ();
		playerDestroyer.gameObject.SetActive (false);
	}

	public override void GameResume()
	{
		gameTimer.StartTimer ();
		GameRunning = true;
		spawner.StartSpawningEnemies ();
		playerDestroyer.gameObject.SetActive (true);
	}

	public override void GameStart()
	{
		gameTimer.StopTimer ();
		GameRunning = false;
		WaitBeforeGame.GetComponent<UIOpenCloseAnimator>().Open();
		WaitBeforeGame.StartCountDown ();
		spawner.StopSpawningEnemies ();
		playerDestroyer.gameObject.SetActive (true);
	}

	private void GameEnded(bool won)
	{
		if (GameRunning) 
		{
			gameTimer.StopTimer ();
			GameRunning = false;
			Display.ShowGameResult (won);
			result = won ? GameState.Won : GameState.Lost;
			playerDestroyer.gameObject.SetActive (false);
			WaitAfterGame.StartCountDown ();
			spawner.Reset ();
		}
	}

	// Use this for initialization
	private void Start()
	{
		WaitBeforeGame.Listener = WaitFinished;
		WaitAfterGame.Listener = WaitAfterFinished;
		playerDestroyer.Listener = () => GameEnded (false);
		gameTimer.Listener = () => GameEnded(true);
	}

	private void WaitAfterFinished()
	{
		Listener(result);
	}

	private void WaitFinished()
	{
		WaitBeforeGame.GetComponent<UIOpenCloseAnimator>().Close();
		gameTimer.StartTimer ();
		GameRunning = true;
		spawner.StartSpawningEnemies ();
	}
}
