using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public float Speed;
    private Vector3 velocity;
    public Text Debug;

    private void Start()
    {
        velocity = Vector3.up;
    }

    private void Update()
    {
        transform.localPosition += velocity * Speed * Time.deltaTime;
        GetComponent<LineRenderer>().SetPosition(1, new Vector3(0.0f, 0.0f, (-0.5f - transform.localPosition.z) / transform.localScale.z));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Paddle")
        {
            Debug.text = "" + other.GetComponent<PaddleController>().GetNormal();
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