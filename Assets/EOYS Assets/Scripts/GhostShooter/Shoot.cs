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
        currentTime = 0.0f;
    }

    // Update is called once per frame
    private void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime < 0.0f)
        {
            currentTime = 0.0f;
        }
    }

    public void Attack()
    {
        if (currentTime == 0.0f)
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
            bullet.transform.position = new Vector3(0.0f, 0.0f, 10.0f);

            currentTime = Cooldown;
        }
    }
}