using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaitTimeBeforeGame : MonoBehaviour {

    public Text[] CountDownText;

    private bool CountDown;
    private float countDownTime;
    private float timeLeft;

    public delegate void OnTimerFinished();

    //Call listener(GameState.Won) or listener(GameState.Lost) when they won or lost
    public OnTimerFinished Listener { private get; set; }

    public void StartCountDown()
    {
        CountDown = true;
    }

	// Use this for initialization
	void Start () {
        CountDown = false;
        countDownTime = 3.0f;
        timeLeft = countDownTime;
	}
	
    public void ResetWait()
    {
        CountDown = false;
        timeLeft = countDownTime;
    }

	// Update is called once per frame
	void Update () {
	    if(CountDown)
        {
            timeLeft -= Time.deltaTime; 
            foreach (Text text in CountDownText)
            {
                text.text = "" + Mathf.Round(timeLeft);
            }
        }

        if(timeLeft <= 0.0f)
        {
            CountDown = false;
            Listener();
        }
	}
}
