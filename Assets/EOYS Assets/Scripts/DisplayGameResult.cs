using UnityEngine;
using UnityEngine.UI;

public class DisplayGameResult : MonoBehaviour
{
    public Text[] GameResultText;
    public GameObject[] Panels;
    public BallController PongBall;
    public GameTimer PongGameTimer;

    // Use this for initialization
    private void Start()
<<<<<<< HEAD
=======
    {
        PanelActivation(false);
    }

    private void PanelActivation(bool activate)
>>>>>>> origin/master
    {
        PanelActivation(false, true);
        Reset();
    }

    public void Reset()
    {
        foreach (Text t in GameResultText)
        {
            t.text = "";
        }
    }

<<<<<<< HEAD
    public void PanelActivation(bool activate, bool won)
    {
        foreach (GameObject panel in Panels)
        {
            panel.SetActive(activate);
            foreach (Text t in GameResultText)
=======
    // Update is called once per frame
    private void Update()
    {
        foreach (Text t in GameResultText)
        {
            if (PongBall.GameLost)
            {
                PanelActivation(true);
                t.text = ("You Lost!\nTry Again!");
            }
            else if (!PongBall.GameLost && PongGameTimer.Finished)
>>>>>>> origin/master
            {
                if (won)
                {
                    t.text = "Congratulations!\nYou Won!";
                }
                else
                {
                    t.text = ("You Lost!\nTry Again!");
                }
            }
        }
    }
}