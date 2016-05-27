using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public VelocityMove bullet;
    public Transform bulletParent;
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
        Vector3 direction = Probe2.localPosition - Probe.localPosition;
        float parameter = Probe.localPosition.y / direction.y;
        Vector3 target = Probe.localPosition - parameter * direction;
        Vector3 toTarget = target - transform.localPosition;
        VelocityMove spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.parent = bulletParent;
        spawnedBullet.transform.localPosition = transform.localPosition;
        spawnedBullet.velocity = speed * toTarget;
    }

    private void Start()
    {
        time = 0.0f;
        running = true;
        Activate();
    }

    private void Update()
    {
        Probe.position = Vector3.zero;
        Probe2.position = Vector3.forward;

        Vector3 local = Probe.localPosition;
        local.x = Mathf.Clamp(local.x, -0.5f, 0.5f);
        local.y = 1.0f;
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