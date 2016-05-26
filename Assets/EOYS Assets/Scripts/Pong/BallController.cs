using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public float Speed;
    public Text Debug;
    public bool GameLost { private set; get; }
    private Vector3 velocity;

    private void Start()
    {
        velocity = Vector3.up;
        GameLost = false;
        
    }

    private void Update()
    {
        if (!PongGameMiniGameManager.Paused)
        {
            if (!GameTimer.Finished)
            {
                transform.localPosition += velocity * Speed * Time.deltaTime;
                GetComponent<LineRenderer>().SetPosition(1, new Vector3(0.0f, 0.0f, (-0.5f - transform.localPosition.z) / transform.localScale.z));
            }
            if (transform.localPosition.y >= 1.0f)
            {
                GameLost = true;
                GetComponentInParent<PongGameMiniGameManager>().GameEnd();
            }
            else if (GameTimer.Finished)
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
                Debug.text = "" + other.GetComponent<PaddleController>().GetNormal();
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