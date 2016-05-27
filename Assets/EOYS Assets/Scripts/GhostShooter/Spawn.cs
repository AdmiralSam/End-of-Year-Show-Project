using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Color color;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Ball"))
        {
            if (Random.Range(0.0f, 1.0f) < 0.1f)
            {
                GetComponentInChildren<HealthBar>().takeDamage(2);
            }
            else
            {
                GetComponentInChildren<HealthBar>().takeDamage(1);
            }
        }
    }

    // Use this for initialization
    private void Start()
    {
        //this.GetComponent<Renderer>().material.color = new Color(0F, 179 / 255F, 1F, 1F);
        this.GetComponent<Renderer>().material.color = color;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}