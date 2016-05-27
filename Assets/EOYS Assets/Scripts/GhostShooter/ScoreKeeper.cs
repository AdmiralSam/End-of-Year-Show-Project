using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Text[] scoreFields;
    public int Score { private set; get; }

    public void IncreaseScore(int points)
    {
        Score += points;
    }

    public void Reset()
    {
        Score = 0;
    }

    public void TakeDamage(int damage)
    {
        //Score -= damage;
    }

    // Use this for initialization
    private void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        foreach (Text text in scoreFields)
        {
            text.text = "Score: " + Score;
        }
    }
}