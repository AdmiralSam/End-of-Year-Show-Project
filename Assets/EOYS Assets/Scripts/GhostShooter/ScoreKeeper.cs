using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

    public int Score { private set; get; }

	// Use this for initialization
	void Start () {
        Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TakeDamage(int damage)
    {
        //Score -= damage;
    }

    public void IncreaseScore(int points)
    {
        Score += points;
    }
}
