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
    {
        PanelActivation(false);
    }

    private void PanelActivation(bool activate)
    {
        foreach (GameObject panel in Panels)
        {
            panel.SetActive(activate);
        }
    }

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
            {
                PanelActivation(true);
                t.text = "Congratulations!\nYou Won!";
            }
        }
    }
}