using UnityEngine;

//Not to be modified, extend with class and override MonoBehaviour's Update functions only
public abstract class MinigameManager : MonoBehaviour
{
    public delegate void OnGameFinished(GameState state);

    public enum GameState { Won, Lost }

    //Call listener(GameState.Won) or listener(GameState.Lost) when they won or lost
    public OnGameFinished Listener { protected get; set; }

    //Pause game here
    public abstract void GamePause();

    //Remove all game objects and reset variables here
    public abstract void GameReset();

    //Resume paused game here
    public abstract void GameResume();

    //Add all game objects and initialize variables here
    public abstract void GameStart();
}