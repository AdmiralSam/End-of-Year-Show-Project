using UnityEngine;

public class BossTakeDamage : MonoBehaviour
{
    public BossHealthBar healthBar;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Player"))
        {
            healthBar.TakeDamage(5);
        }
    }
}