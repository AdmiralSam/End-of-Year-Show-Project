using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    //public Image HealthBar1, HealthBar2, HealthBar3;

    public OnStageDepleted Listener;

    private readonly Color green = new Color32(46, 204, 113, 255);

    private readonly Color red = new Color32(231, 76, 60, 255);

    private readonly Color yellow = new Color32(241, 196, 15, 255);

    private int health;

    public delegate void OnStageDepleted(int stage);

    public void Reset()
    {
        health = 300;
    }

    public void TakeDamage(int damage)
    {
        if (health > 200 && health - damage <= 200)
        {
            if (Listener != null)
            {
                Listener(1);
            }
        }
        else if (health > 100 && health - damage <= 100)
        {
            if (Listener != null)
            {
                Listener(2);
            }
        }
        else if (health - damage <= 0)
        {
            if (Listener != null)
            {
                Listener(3);
            }
        }
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
        UpdateHealthBars();
    }

    private void Start()
    {
        Reset();
    }

    private void UpdateHealthBars()
    {
        /*
        int intermediateHealth = health % 100;
        Color currentColor = intermediateHealth > 50 ? Color.Lerp(yellow, green, (intermediateHealth - 50.0f) / 50.0f) : Color.Lerp(red, yellow, intermediateHealth / 50.0f);
        if (health >= 200)
        {
            HealthBar1.color = currentColor;
            HealthBar2.color = green;
            HealthBar3.color = green;

            HealthBar1.fillAmount = intermediateHealth / 100.0f;
            HealthBar2.fillAmount = 1.0f;
            HealthBar3.fillAmount = 1.0f;
        }
        else if (health >= 100)
        {
            HealthBar2.color = currentColor;
            HealthBar1.color = green;

            HealthBar1.fillAmount = 0.0f;
            HealthBar2.fillAmount = intermediateHealth / 100.0f;
            HealthBar3.fillAmount = 1.0f;
        }
        else
        {
            HealthBar1.color = currentColor;

            HealthBar1.fillAmount = 0.0f;
            HealthBar2.fillAmount = 0.0f;
            HealthBar3.fillAmount = intermediateHealth / 100.0f;
        }
        */
    }
}