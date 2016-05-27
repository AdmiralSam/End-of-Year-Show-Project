using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public delegate void OnPlayerDeath();

    public OnPlayerDeath Listener { private get; set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Boss"))
        {
            gameObject.SetActive(false);
            if (Listener != null)
            {
                Listener();
            }
        }
    }
}