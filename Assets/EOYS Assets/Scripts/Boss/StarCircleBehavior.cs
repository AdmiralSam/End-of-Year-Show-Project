using System.Collections.Generic;
using UnityEngine;

public class StarCircleBehavior : MonoBehaviour
{
    public VelocityMove bullet;
    public Transform bulletParent;
    public float radius;
    public float setupTime;
    public float speed;
    public float spread;
    public float timeBetweenMoves;
    private State currentState;
    private int index;
    private bool running;
    private List<Vector3> starPoints;
    private Vector3 startingPoint;
    private float time;

    private enum State { Idle, SettingUp, Moving }

    public void Activate()
    {
        currentState = State.SettingUp;
        startingPoint = transform.localPosition;
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

    private float DistanceAtRadiusWithAngle(float radius, float angle)
    {
        return Vector2.Distance(new Vector2(radius, 0), new Vector2(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle)));
    }

    private void Fire()
    {
        int numberOfVertical = 2;
        while (DistanceAtRadiusWithAngle(1.0f, Mathf.PI / (numberOfVertical - 1)) > spread)
        {
            numberOfVertical++;
        }
        numberOfVertical--;
        for (int i = 0; i < numberOfVertical; i++)
        {
            float angle = (float)i / (numberOfVertical - 1) * Mathf.PI;
            float radius = Mathf.Sin(angle);
            int numberInRing = 2;
            while (DistanceAtRadiusWithAngle(radius, 2 * Mathf.PI / numberInRing) > spread)
            {
                numberInRing++;
            }
            numberInRing--;
            for (int j = 0; j < numberInRing; j++)
            {
                float horizontalAngle = (float)j / numberInRing * 2 * Mathf.PI;
                Vector3 target = new Vector3(radius * Mathf.Cos(horizontalAngle), radius * Mathf.Sin(horizontalAngle), Mathf.Cos(angle));
                VelocityMove spawnedBullet = Instantiate(bullet);
                spawnedBullet.transform.parent = bulletParent;
                spawnedBullet.transform.localPosition = transform.localPosition;
                spawnedBullet.velocity = speed * target.normalized;
            }
        }
    }

    private void Start()
    {
        currentState = State.Idle;
        time = 0.0f;
        running = true;
        starPoints = new List<Vector3>();
        for (int i = 0; i < 5; i++)
        {
            int index = i * 2 % 5;
            float angle = Mathf.PI / 2 + index * 2 * Mathf.PI / 5;
            starPoints.Add(new Vector3(radius * Mathf.Cos(angle), transform.localPosition.y, radius * Mathf.Sin(angle)));
        }
        this.index = 0;
    }

    private void Update()
    {
        if (running)
        {
            switch (currentState)
            {
                case State.SettingUp:
                    time += Time.deltaTime;
                    if (time <= setupTime)
                    {
                        transform.localPosition = Vector3.Lerp(startingPoint, starPoints[index], time / setupTime);
                    }
                    else
                    {
                        time = 0.0f;
                        currentState = State.Moving;
                        Fire();
                    }
                    break;

                case State.Moving:
                    time += Time.deltaTime;
                    if (time <= timeBetweenMoves)
                    {
                        transform.localPosition = Vector3.Lerp(starPoints[index], starPoints[(index + 1) % 5], time / timeBetweenMoves);
                    }
                    else
                    {
                        time = 0.0f;
                        index = (index + 1) % 5;
                        Fire();
                    }
                    break;
            }
        }
    }
}