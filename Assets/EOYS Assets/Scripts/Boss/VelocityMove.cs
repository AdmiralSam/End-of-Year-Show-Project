using UnityEngine;

public class VelocityMove : MonoBehaviour
{
    public Vector3 velocity;

    private void Update()
    {
        transform.localPosition += velocity * Time.deltaTime;
    }
}