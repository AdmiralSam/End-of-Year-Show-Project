using UnityEngine;

public class BossMinigameManager : MinigameManager
{
    public WaitTimeAfterGame afterTimer;
    public WaitTimeBeforeGame beforeTimer;
    public BossBehaviorSwitcher boss;
    public DisplayGameResult display;
    public PlayerHit hit;
    public PlayerController player;
    public Animator unityChan;
    private State currentState;
    private GameState result;
    private float time;

    private enum State { Idle, Waiting, Playing, Finished }

    public override void GamePause()
    {
        switch (currentState)
        {
            case State.Playing:

                player.Pause();
                boss.Pause();
                break;
        }
    }

    public override void GameReset()
    {
        player.Reset();
        boss.Reset();
        beforeTimer.ResetWait();
        afterTimer.ResetWait();
        time = 0.0f;
        currentState = State.Idle;
        display.PanelActivation(false, false);
        display.Reset();
        boss.ResetPosition();
    }

    public override void GameResume()
    {
        switch (currentState)
        {
            case State.Playing:
                player.Resume();
                boss.Resume();
                break;
        }
    }

    public override void GameStart()
    {
        currentState = State.Waiting;
        beforeTimer.gameObject.SetActive(true);
        beforeTimer.StartCountDown();
        hit.gameObject.SetActive(true);
    }

    private void BossDied()
    {
        result = GameState.Won;
        afterTimer.StartCountDown();
        display.PanelActivation(true, true);
        boss.Reset();
        player.Reset();
        unityChan.CrossFade("LOSE00", 0.3f);
    }

    private void PlayerDied()
    {
        result = GameState.Lost;
        afterTimer.StartCountDown();
        display.PanelActivation(true, false);
        boss.Pause();
        player.Reset();
    }

    private void Start()
    {
        beforeTimer.Listener = StartPlaying;
        hit.Listener = PlayerDied;
        boss.Listener = BossDied;
        afterTimer.Listener = () => Listener(result);
    }

    private void StartPlaying()
    {
        currentState = State.Playing;
        beforeTimer.gameObject.SetActive(false);
        player.Activate();
        boss.Activate();
    }
}