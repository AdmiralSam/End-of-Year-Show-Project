using UnityEngine;

public class Shoot : MonoBehaviour
{
    public MoveBall Bullet;
    public float Speed;
    public float Cooldown;

    private float currentTime;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        currentTime += Time.deltaTime;
    }

    public void Attack()
    {
        if (currentTime >= Cooldown)
        {
            MoveBall bullet = Instantiate(this.Bullet);
            bullet.transform.parent = transform;
            bullet.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            Vector3 forwardPosition = bullet.transform.localPosition;
            bullet.transform.position = new Vector3(0.0f, 0.0f, 1.0f);
            Vector3 startingPosition = bullet.transform.localPosition;
            Vector3 forward = forwardPosition - startingPosition;
            bullet.velocity = -forward * Speed;
            bullet.gameObject.SetActive(true);

            currentTime = 0.0f;
        }
    }
}