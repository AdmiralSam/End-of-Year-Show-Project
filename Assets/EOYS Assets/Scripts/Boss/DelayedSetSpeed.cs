using UnityEngine;

public class DelayedSetSpeed : MonoBehaviour
{
    public float delay;
    public float speed;
    private float time;

    private void Start()
    {
        time = 0.0f;
    }

    private void Update()
    {
        if (time < delay && time + Time.deltaTime > delay)
        {
            VelocityMove velocityMove = GetComponent<VelocityMove>();
            velocityMove.velocity = speed * velocityMove.velocity.normalized;
        }
        else {
            time += Time.deltaTime;
        }
    }
}