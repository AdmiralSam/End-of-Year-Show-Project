using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateTimerText : MonoBehaviour {

    public GameTimer gameTimer;
    public Text timerText;

    // Use this for initialization
    void Start () {
        timerText.text = "1:00";
    }
	
	// Update is called once per frame
	void Update () {
        timerText.text = string.Format("{0:00} : {1:00}", 0, Mathf.Round(gameTimer.GameTimeLeft));
    }
}
