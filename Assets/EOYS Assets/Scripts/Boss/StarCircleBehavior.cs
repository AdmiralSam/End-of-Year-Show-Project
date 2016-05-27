using System.Collections.Generic;
using UnityEngine;

public class StarCircleBehavior : MonoBehaviour
{
    public VelocityMove bullet;
    public Transform player;
    public Transform bulletParent;
    public float timeBetweenMoves;
    public float setupTime;
    public float time;
    private bool running;
    private Vector3 startingPoint;
    private List<Vector3> starPoints;

    private enum State { Idle, SettingUp, Moving }

    private State currentState;

    private void Start()
    {
        currentState = State.Idle;
        time = 0.0f;
        running = true;
        starPoints = new List<Vector3>();
    }

    private void Update()
    {
        if (running)
        {
            switch (currentState)
            {
                case State.SettingUp:
                    break;

                case State.Moving:
                    break;
            }
        }
    }

    public void Activate()
    {
        currentState = State.SettingUp;
    }

    public void Pause()
    {
        running = false;
    }

    public void Resume()
    {
        running = true;
    }

    public void Reset()
    {
        currentState = State.Idle;
        time = 0.0f;
        running = true;
        List<GameObject> bullets = new List<GameObject>();
        foreach (Transform child in bulletParent)
        {
            bullets.Add(child.gameObject);
        }
        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
    }
}