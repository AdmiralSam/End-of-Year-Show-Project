using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayGameResult : MonoBehaviour {

    public Text[] GameResultText;
    public GameObject[] Panels;
    public BallController PongBall;

	// Use this for initialization
	void Start () {
        PanelActivation(false);
	}
	
    void PanelActivation(bool activate)
    {
        foreach (GameObject panel in Panels)
        {
            panel.SetActive(activate);
        }
    }

	// Update is called once per frame
	void Update ()
    {
	    foreach(Text t in GameResultText)
        {
            if(PongBall.GameLost)
            {
                PanelActivation(true);
                t.text = ("You Lost!\nTry Again!");
            }
            else if(!PongBall.GameLost && GameTimer.Finished)
            {
                PanelActivation(true);
                t.text = "Congratulations!\nYou Won!";
            }
        }
	}
}
