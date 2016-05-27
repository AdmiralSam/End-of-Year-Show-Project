using UnityEngine;

public class VelocityMove : MonoBehaviour
{
    public Vector3 velocity;

    private bool running;

    public void Pause()
    {
        running = false;
    }

    public void Resume()
    {
        running = true;
    }

    private void Start()
    {
        running = true;
    }

    private void Update()
    {
        if (running)
        {
            transform.localPosition += velocity * Time.deltaTime;
        }
    }
}