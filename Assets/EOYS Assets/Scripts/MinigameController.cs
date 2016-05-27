using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    public UIOpenCloseAnimator HUD;
    public GameObject hudCanvas;
    public ParameterizedAnimator strengthBar;
    public float StrengthChangeTime;
    private string currentMinigame;
    private State currentState;
    private float currentStrength;
    private Dictionary<string, MinigameState> minigames;

    private enum MinigameState { New, Active, Finished }

    private enum State { Neutral, LosingStrength, GainingStrength }

    public void EnteredDimension()
    {
        GameObject.Find(currentMinigame).GetComponentInChildren<UIOpenCloseAnimator>().Close();
        GameObject.Find(currentMinigame).GetComponentInChildren<MinigameOpenCloseAnimator>().Open();
        GameObject.Find(currentMinigame).GetComponentInChildren<MinigameManager>().GameStart();
        GameObject.Find(currentMinigame).GetComponentInChildren<MinigameManager>().Listener = GameEnded;
        minigames[currentMinigame] = MinigameState.Active;
        currentState = State.GainingStrength;
        hudCanvas.SetActive(true);
        HUD.Open();
    }

    public void EnteredTarget(string target)
    {
        if (target == "Target 4")
        {
            if (minigames["Target 1"] != MinigameState.Finished || minigames["Target 2"] != MinigameState.Finished || minigames["Target 3"] != MinigameState.Finished)
            {
                return;
            }
        }
        currentMinigame = target;
        switch (minigames[target])
        {
            case MinigameState.Active:
                currentState = State.GainingStrength;
                GameObject.Find(currentMinigame).GetComponentInChildren<MinigameOpenCloseAnimator>().Open();
                GameObject.Find(currentMinigame).GetComponentInChildren<MinigameManager>().GameResume();
                break;

            case MinigameState.New:
                GameObject.Find(target).GetComponentInChildren<UIOpenCloseAnimator>().Open();
                break;

            case MinigameState.Finished:
                GameObject.Find(target).GetComponentInChildren<UIOpenCloseAnimator2>().Open();
                break;
        }
    }

    public void LeftTarget(string target)
    {
        switch (minigames[target])
        {
            case MinigameState.Active:
                currentState = State.LosingStrength;
                GameObject.Find(currentMinigame).GetComponentInChildren<MinigameOpenCloseAnimator>().Close();
                GameObject.Find(currentMinigame).GetComponentInChildren<MinigameManager>().GamePause();
                break;

            case MinigameState.New:
                GameObject.Find(target).GetComponentInChildren<UIOpenCloseAnimator>().Close();
                break;

            case MinigameState.Finished:
                GameObject.Find(target).GetComponentInChildren<UIOpenCloseAnimator2>().Close();
                break;
        }
    }

    private void GameEnded(MinigameManager.GameState state)
    {
        currentStrength = 0.0f;
        currentState = State.Neutral;
        GameObject.Find(currentMinigame).GetComponentInChildren<MinigameOpenCloseAnimator>().Close();
        GameObject.Find(currentMinigame).GetComponentInChildren<MinigameManager>().GameReset();
        minigames[currentMinigame] = state == MinigameManager.GameState.Won ? MinigameState.Finished : MinigameState.New;
        if (state == MinigameManager.GameState.Won)
        {
            GameObject.Find(currentMinigame).GetComponentInChildren<UIOpenCloseAnimator2>().Open();
        }
        else
        {
            GameObject.Find(currentMinigame).GetComponentInChildren<UIOpenCloseAnimator>().Open();
        }
        HUD.Close();
    }

    private void Start()
    {
        minigames = new Dictionary<string, MinigameState>();
        minigames["Target 1"] = MinigameState.New;
        minigames["Target 2"] = MinigameState.New;
        minigames["Target 3"] = MinigameState.New;
        minigames["Target 4"] = MinigameState.New;
        HUD.OnClose = () => hudCanvas.SetActive(false);
    }

    private void Update()
    {
        if (currentMinigame != null && minigames[currentMinigame] == MinigameState.Active)
        {
            switch (currentState)
            {
                case State.GainingStrength:
                    currentStrength += Time.deltaTime / StrengthChangeTime;
                    if (currentStrength > 1.0f)
                    {
                        currentStrength = 1.0f;
                        currentState = State.Neutral;
                    }
                    break;

                case State.LosingStrength:
                    currentStrength -= Time.deltaTime / StrengthChangeTime;
                    if (currentStrength < 0.0f)
                    {
                        GameEnded(MinigameManager.GameState.Lost);
                        currentMinigame = null;
                    }
                    break;
            }
            strengthBar.SetParameter(currentStrength);
        }
    }
}