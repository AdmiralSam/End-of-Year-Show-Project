﻿using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public float Speed;
    public Text Debug;
    public GameTimer PongGameTimer;
    private Vector3 velocity;
    private bool running;

    private void Start()
    {
        velocity = Vector3.up;
<<<<<<< HEAD
    }

    public void ResetBall()
    {
        transform.localPosition = new Vector3(0.0f, 0.2f, 0.0f);
        velocity = Vector3.up;
    }

    public void StartBallMovement()
    {
        running = true;
=======
        GameLost = false;
>>>>>>> origin/master
    }

    private void Update()
    {
        if (PongGameMiniGameManager.GameRunning)
        {
            if (running)
            {
                transform.localPosition += velocity * Speed * Time.deltaTime;
                GetComponent<LineRenderer>().SetPosition(1, new Vector3(0.0f, 0.0f, (-0.5f - transform.localPosition.z) / transform.localScale.z));
            }
            if (transform.localPosition.y >= 1.0f)
            {
                GetComponentInParent<PongGameMiniGameManager>().GameEnd();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Paddle")
        {
            if (Debug != null)
            {
                Debug.text = other.GetComponent<PaddleController>().GetNormal() + "|" + velocity;
            }
            velocity = Vector3.Reflect(velocity, other.GetComponent<PaddleController>().GetNormal().normalized);
        }
        else
        {
            string[] normalString = other.name.Split(':');
            Vector3 normal = new Vector3(float.Parse(normalString[0]), float.Parse(normalString[1]), float.Parse(normalString[2]));
            velocity = Vector3.Reflect(velocity, normal);
        }
    }
}