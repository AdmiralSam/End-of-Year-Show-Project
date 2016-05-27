using UnityEngine;
using System.Collections;

public class WaitTimeAfterGame : MonoBehaviour {

	private bool countDown;
	private float countDownTime;
	private float timeLeft;

	public delegate void OnTimerFinished();
	public OnTimerFinished Listener { private get; set; }

	public void StartCountDown()
	{
		countDown = true;
	}

	public void ResetWait()
	{
		countDown = false;
		timeLeft = countDownTime;
	}

	// Use this for initialization
	void Start () {
		countDown = false;
		countDownTime = 3.0f;
		timeLeft = countDownTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(countDown)
		{
			timeLeft -= Time.deltaTime; 
		}

		if(timeLeft < 0.0f)
		{
			timeLeft = 0.0f;
			countDown = false;

			if (Listener != null) 
			{
				Listener ();
			}
		}
	}
}
