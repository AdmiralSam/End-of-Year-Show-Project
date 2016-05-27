using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public Vector3 velocity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Spawn"))
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.localPosition += velocity * Time.deltaTime;

        if (transform.localPosition.y < 0)
        {
            Destroy(gameObject);
        }
    }
}