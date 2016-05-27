using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BulletPool pool;
    public Transform Probe;
    public Transform Probe2;

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
        Vector3 direction = Probe2.localPosition - Probe.localPosition;
        float parameter = Probe.localPosition.y / direction.y;
        Vector3 target = Probe.localPosition - parameter * direction;
        Vector3 toTarget = target - transform.localPosition;
        VelocityMove spawnedBullet = pool.GetBullet();
        spawnedBullet.transform.localPosition = transform.localPosition;
        spawnedBullet.velocity = speed * toTarget;
    }

    private void Start()
    {
        time = 0.0f;
        running = true;
    }

    private void Update()
    {
        Probe.position = Vector3.zero;
        Probe2.position = Vector3.forward;

        Vector3 local = Probe.localPosition;
        local.x = Mathf.Clamp(local.x, -0.5f, 0.5f);
        local.y = transform.localPosition.y;
        local.z = Mathf.Clamp(local.z, -0.5f, 0.5f);
        transform.localPosition = Vector3.Lerp(transform.localPosition, local, 0.5f);

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