using UnityEngine;

public class SimpleShootBehavior : MonoBehaviour
{
    public Transform player;
    public BulletPool pool;
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
        pool.Pause();
    }

    public void Reset()
    {
        currentState = State.Idle;
        time = 0.0f;
        running = true;
        pool.Reset();
    }

    public void Resume()
    {
        running = true;
        pool.Resume();
    }

    private void Fire()
    {
        Vector3 toPlayer = player.transform.localPosition - transform.localPosition;
        toPlayer.Normalize();
        VelocityMove spawnedBullet = pool.GetBullet();
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