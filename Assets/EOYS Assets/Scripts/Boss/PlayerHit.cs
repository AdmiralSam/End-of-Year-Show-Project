using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Boss"))
        {
            Destroy(gameObject);
        }
    }
}