using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int maxHealth;
    public Image first;
    public Image second;
    public Image third;

    public ScoreKeeper scoreKeeper;

    public int CurrentHealth { get; private set; }

    private Color green = new Color(50 / 255F, 205 / 255F, 50 / 255F, 0.5F);
    private Color orange = new Color(1F, 153 / 255F, 0F, 0.5F);
    private Color red = new Color(1.0F, 0F, 0F, 0.5F);
    private Color black = new Color(0.5F, 0.5F, 0.5F, 0.5F);

    // Use this for initialization
    private void Start()
    {
        CurrentHealth = maxHealth;
        setHealthBarColor(green);
    }

    // Update is called once per frame
    private void Update()
    {
        if (CurrentHealth == 0)
        {
            setHealthBarColor(black);
            scoreKeeper.IncreaseScore(maxHealth);
            Destroy(this.transform.parent.gameObject);
            return;
        }
        if (CurrentHealth < maxHealth)
        {
            setHealthBarColor(orange);
        }
        if (CurrentHealth <= maxHealth / 3)
        {
            setHealthBarColor(red);
        }
    }

    public void takeDamage(int damagePoints)
    {
        CurrentHealth -= Mathf.Min(damagePoints, CurrentHealth);
    }

    private void setHealthBarColor(Color color)
    {
        switch (maxHealth)
        {
            case 1:
                setHealthColors1(color);
                break;

            case 2:
                setHealthColors2(color);
                break;

            case 3:
                setHealthColors3(color);
                break;

            default:
                break;
        }
    }

    private void setHealthColors1(Color color)
    {
        first.color = color;
    }

    private void setHealthColors2(Color color)
    {
        first.color = color;
        second.color = color;

        if (color == orange)
        {
            second.color = black;
        }
    }

    private void setHealthColors3(Color color)
    {
        first.color = color;
        second.color = color;
        third.color = color;

        if (color == orange)
        {
            third.color = black;
        }
        if (color == red)
        {
            second.color = black;
            third.color = black;
        }
    }
}