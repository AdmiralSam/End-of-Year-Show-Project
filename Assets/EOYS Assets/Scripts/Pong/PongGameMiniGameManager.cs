using UnityEngine;
using UnityEngine.UI;

public class PongGameMiniGameManager : MinigameManager
{
    public static bool Paused { private set; get; }

    public Text Debug;

    public GameTimer PongGameTimer;
    public Text[] GameResult;
    public GameObject AllGameObjectsContainer;
    public BallController PongBallController;
    public GameObject PongBall;
    public float waitTime;

    private bool waitBeforeGameStart;
    private bool waitAfterGameResult;
    private float timeWaited;

    private bool gameResultSet;

    public override void GamePause()
    {
        Paused = true;
        PongGameTimer.StopTimer();
    }

    public override void GameReset()
    {
        Paused = true;
        gameResultSet = false;
        PongGameTimer.StopTimer();
    }

    public override void GameResume()
    {
        if (waitBeforeGameStart)
        {
            WaitTime.CountDown = true;
        }
        else
        {
            PongGameTimer.StartTimer();
        }

        Paused = false;
    }

    public override void GameStart()
    {
        waitBeforeGameStart = true;
        waitAfterGameResult = false;
        timeWaited = 0.0f;

        if (PongBallController.transform.parent.gameObject == null)
        {
            Instantiate(PongBall);
        }
        gameResultSet = false;
        WaitTime.CountDown = true;
        //ShowRules();
        //PongGameTimer.StartTimer();
        Paused = true;
    }

    public void GameEnd()
    {
        if (!gameResultSet)
        {
            PongGameTimer.StopTimer();
            Destroy(PongBallController.gameObject);
            AllGameObjectsContainer.gameObject.SetActive(false);
            waitAfterGameResult = true;
        }
    }

    // Use this for initialization
    private void Start()
    {
        Paused = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (waitBeforeGameStart)
        {
            timeWaited += Time.deltaTime;
            if (timeWaited >= waitTime)
            {
                waitBeforeGameStart = false;
                timeWaited = 0.0f;
                PongGameTimer.ResetTimer();
                PongGameTimer.StartTimer();
                Paused = false;
            }
        }
        if (waitAfterGameResult)
        {
            timeWaited += Time.deltaTime;
            if (timeWaited >= waitTime)
            {
                waitAfterGameResult = false;
                if (PongBallController.GameLost)
                {
                    Listener(GameState.Lost);
                }
                else
                {
                    Listener(GameState.Won);
                }
            }
        }
    }
}