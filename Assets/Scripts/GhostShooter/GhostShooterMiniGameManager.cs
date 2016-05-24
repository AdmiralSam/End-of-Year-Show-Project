using UnityEngine;
using UnityEngine.UI;

public class GhostShooterMiniGameManager : MinigameManager
{
    public GameTimer gameTimer;
    public ScoreKeeper scoreKeeper;

    private bool gameWon;

    public override void GamePause()
    {
        gameTimer.StopTimer();
    }

    public override void GameReset()
    {
        gameWon = false;
        gameTimer.ResetTimer();
    }

    public override void GameResume()
    {
        gameTimer.StartTimer();
    }

    public override void GameStart()
    {
        gameWon = false;
        gameTimer.StartTimer();
    }

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if(gameTimer.GameTimeLeft <= 0)
        {
            ShowEndGameScreen();
        }
    }

    private void ShowEndGameScreen()
    {
        if (scoreKeeper.Score >= 100)
        {
            gameWon = true;
        }
    }
}