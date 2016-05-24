using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateScoreText : MonoBehaviour {

    public ScoreKeeper scoreKeeper;
    public Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText.text = "0/100";
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = scoreKeeper.Score + "/100";
	}
}
