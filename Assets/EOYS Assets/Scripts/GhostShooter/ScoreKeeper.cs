using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public int Score { private set; get; }
	public int ScoreToWin;
    public Text[] scoreFields;

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
            text.text = "Score: " + Score + " / " + ScoreToWin;
        }
    }

    public void TakeDamage(int damage)
    {
        //Score -= damage;
    }

    public void IncreaseScore(int points)
    {
        Score += points;
    }

    public void Reset()
    {
        Score = 0;
    }
}