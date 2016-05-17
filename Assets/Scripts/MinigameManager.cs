﻿using UnityEngine;

//Not to be modified, extend with class and override MonoBehaviour's Update functions only
public abstract class MinigameManager : MonoBehaviour
{
    public enum GameState { Won, Lost }

    public delegate void OnGameFinished(GameState state);

    //Call listener(GameState.Won) or listener(GameState.Lost) when they won or lost
    public OnGameFinished Listener { protected get; set; }

    //Add all game objects and initialize variables here
    public abstract void GameStart();

    //Resume paused game here
    public abstract void GameResume();

    //Pause game here
    public abstract void GamePause();

    //Remove all game objects and reset variables here
    public abstract void GameReset();
}