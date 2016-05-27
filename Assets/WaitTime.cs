using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaitTime : MonoBehaviour {

    public static bool CountDown;
    public Text[] CountDownText;

    private float countDownTime;
    private float timeLeft;


	// Use this for initialization
	void Start () {
        CountDown = false;
        countDownTime = 4.0f;
        timeLeft = countDownTime;
	}
	
	// Update is called once per frame
	void Update () {
	    if(CountDown && !PongGameMiniGameManager.Paused)
        {
            timeLeft -= Time.deltaTime; 
            foreach (Text text in CountDownText)
            {
                text.text = "" + Mathf.Round(timeLeft);
            }
        }

        if(timeLeft <= 0.0f)
        {
            Destroy(gameObject);
        }
	}
}
