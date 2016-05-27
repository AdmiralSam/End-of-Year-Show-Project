using UnityEngine;
using UnityEngine.UI;

public class DisplayGameResult : MonoBehaviour
{
    public Text[] GameResultText;
    public GameObject[] Panels;
    public BallController PongBall;
    public GameTimer PongGameTimer;

    public void PanelActivation(bool activate, bool won)
    {
        foreach (GameObject panel in Panels)
        {
            panel.SetActive(activate);
            foreach (Text t in GameResultText)
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

    public void Reset()
    {
        foreach (Text t in GameResultText)
        {
            t.text = "";
        }
    }

    // Use this for initialization
    private void Start()
    {
        PanelActivation(false, true);
        Reset();
    }
}