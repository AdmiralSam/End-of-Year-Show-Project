using System.Collections.Generic;
using UnityEngine;

public class SimpleShootBehavior : MonoBehaviour
{
    public VelocityMove bullet;
    public Transform bulletParent;
    public Transform player;
    public float speed;
    public float timeBetweenShots;
    private State currentState;
    private bool running;
    private float time;

    private enum State { Idle, Shooting }

    public void Activate()
    {
        currentState = State.Shooting;
    }

    public void Pause()
    {
        running = false;
        foreach (VelocityMove velocityMove in bulletParent.GetComponentsInChildren<VelocityMove>())
        {
            velocityMove.Pause();
        }
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

    public void Resume()
    {
        running = true;
        foreach (VelocityMove velocityMove in bulletParent.GetComponentsInChildren<VelocityMove>())
        {
            velocityMove.Resume();
        }
    }

    private void Fire()
    {
        Vector3 toPlayer = player.transform.localPosition - transform.localPosition;
        toPlayer.Normalize();
        VelocityMove spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.parent = bulletParent;
        spawnedBullet.transform.localPosition = transform.localPosition;
        spawnedBullet.velocity = speed * toPlayer;
    }

    private void Start()
    {
        currentState = State.Idle;
        time = 0.0f;
        running = true;
    }

    private void Update()
    {
        if (running)
        {
            switch (currentState)
            {
                case State.Shooting:
                    time += Time.deltaTime;
                    if (time > timeBetweenShots)
                    {
                        time = 0.0f;
                        Fire();
                    }
                    break;
            }
        }
    }
}