using UnityEngine;

public class GhostShooterMiniGameManager : MinigameManager
{
    public GameTimer gameTimer;
    public ScoreKeeper scoreKeeper;
    public SpawnEnemies spawner;
    public GameObject hud;

	public WaitTimeBeforeGame WaitBeforeGame;
	public WaitTimeAfterGame WaitAfterGame;
	public DisplayGameResult Display;

	public static bool GameRunning { private set; get; }
	private GameState result;

    public override void GamePause()
    {
        gameTimer.StopTimer();
        hud.SetActive(false);
		GameRunning = false;
		spawner.StopSpawningEnemies ();
    }

    public override void GameReset()
    {
        gameTimer.ResetTimer();
        scoreKeeper.Reset();
        spawner.Reset();
        hud.SetActive(false);

		Display.Reset ();
		WaitAfterGame.ResetWait();
		WaitBeforeGame.ResetWait();
		spawner.StopSpawningEnemies ();
		GameRunning = false;
    }

    public override void GameResume()
    {
        gameTimer.StartTimer();
        hud.SetActive(true);
		spawner.StartSpawningEnemies ();
		GameRunning = true;
    }

    public override void GameStart()
    {
		WaitBeforeGame.GetComponent<UIOpenCloseAnimator>().Open ();
		WaitBeforeGame.StartCountDown();
		spawner.StopSpawningEnemies ();

        //gameTimer.StartTimer();
        hud.SetActive(true);
    }

    // Use this for initialization
    private void Start()
    {
		WaitBeforeGame.Listener = WaitFinished;
		WaitAfterGame.Listener = WaitAfterFinished;
		gameTimer.Listener = () => GameEnded (scoreKeeper.Score >= scoreKeeper.ScoreToWin);
    }

	private void WaitFinished()
	{
		WaitBeforeGame.GetComponent<UIOpenCloseAnimator>().Close ();
		spawner.StartSpawningEnemies ();
		gameTimer.StartTimer();
		GameRunning = true;
	}

	private void WaitAfterFinished()
	{
		Listener(result);
	}

	private void GameEnded(bool won) {
		if (GameRunning)
		{
			GameRunning = false;
			spawner.Reset();
			Display.PanelActivation(true, won);
			gameTimer.StopTimer();
			result = won ? GameState.Won : GameState.Lost;
			WaitAfterGame.StartCountDown();
		}
	}

    // Update is called once per frame
    /*private void Update()
    {
        if (gameTimer.GameTimeLeft <= 0)
        {
            spawner.Reset();
        }
    }*/
}