using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public GameTimer gameTimer;
    public ScoreKeeper scoreKeeper;

    private float speed;
    private float wallPosition;

    // Use this for initialization
    private void Start()
    {
        speed = Random.Range(0.0005f, 0.0015f);
        wallPosition = 1.0f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!gameTimer.Paused)
        {
            float moveHorizontal = Random.Range(-0.0015f, 0.0015f);
            float moveVertical = Random.Range(-0.0015f, 0.0015f);

            transform.localPosition += new Vector3(moveHorizontal, speed, moveVertical);
            Vector3[] linePositions = new Vector3[2];
            linePositions[0] = new Vector3(0.0f, (1.0f - transform.localPosition.y) / transform.localScale.y, 0.0f);
            linePositions[1] = Vector3.zero;
            GetComponent<LineRenderer>().SetPositions(linePositions);
            if (transform.localPosition.y >= wallPosition)
            {
                scoreKeeper.TakeDamage(GetComponentInChildren<HealthBar>().CurrentHealth);
                Destroy(gameObject);
            }
        }
    }
}