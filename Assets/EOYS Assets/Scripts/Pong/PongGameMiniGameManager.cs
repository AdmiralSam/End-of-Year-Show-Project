using UnityEngine;
using UnityEngine.UI;

public class PongGameMiniGameManager : MinigameManager
{
    public static bool GameRunning { private set; get; }

    public Text Debug;

    public GameTimer PongGameTimer;
    public WaitTimeBeforeGame WaitBeforeGame;
    public GameObject AllGameObjectsContainer;
    public BallController PongBallController;
    public DisplayGameResult Display;

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

    public void GameEnd()
    {
        BallDied();
    }

    private void Start()
    {
        WaitBeforeGame.Listener = WaitFinished;
        PongGameTimer.Listener = GameFinished;
    }

    private void WaitFinished()
    {
        WaitBeforeGame.gameObject.SetActive(false);
        GameRunning = true;
        PongGameTimer.StartTimer();
        PongBallController.StartBallMovement();
    }

    private void GameFinished()
    {
        if (GameRunning)
        {
            Display.PanelActivation(true, true);
            GameRunning = false;
            PongGameTimer.StopTimer();
            AllGameObjectsContainer.gameObject.SetActive(false);
        }
    }

    private void BallDied()
    {
        if (GameRunning)
        {
            Display.PanelActivation(true, false);
            GameRunning = false;
            PongGameTimer.StopTimer();
            AllGameObjectsContainer.gameObject.SetActive(false);
        }
    }
}