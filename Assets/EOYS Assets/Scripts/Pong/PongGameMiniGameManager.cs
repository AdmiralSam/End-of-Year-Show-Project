using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PongGameMiniGameManager : MinigameManager
{
    public GameTimer PongGameTimer;
    public Text[] GameResult;
    public BallController PongBall;
    public static bool Paused { private set; get; }
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
        Paused = false;
        PongGameTimer.StartTimer();
    }

    public override void GameStart()
    {
        Paused = true;
        gameResultSet = false;

        //ShowRules();

        PongGameTimer.StartTimer();
    }

    public void GameEnd()
    {
        if (!gameResultSet)
        {
            PongGameTimer.StopTimer();
            if (PongBall.GameLost)
            {
                Destroy(PongBall.gameObject);
                Listener(GameState.Lost);
            }
            else
            {
                Destroy(PongBall.gameObject);
                Listener(GameState.Won);
            }

            gameResultSet = true;
        }
    }
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () { 
        
	}
}
