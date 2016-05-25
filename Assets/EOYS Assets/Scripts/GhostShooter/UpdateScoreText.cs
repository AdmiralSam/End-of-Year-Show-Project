using UnityEngine;
using UnityEngine.UI;

public class UpdateScoreText : MonoBehaviour
{
    public ScoreKeeper scoreKeeper;
    public Text scoreText;

    // Use this for initialization
    private void Start()
    {
        scoreText.text = "0/100";
    }

    // Update is called once per frame
    private void Update()
    {
        scoreText.text = scoreKeeper.Score + "/100";
    }
}