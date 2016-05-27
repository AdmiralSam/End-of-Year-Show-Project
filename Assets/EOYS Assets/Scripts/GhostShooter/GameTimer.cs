using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text[] timeFields;
    public float totalGameTime;

    public delegate void OnTimerFinished();

    public float GameTimeLeft { get; private set; }
    public OnTimerFinished Listener { private get; set; }

    public bool Paused { get; private set; }

    public void ResetTimer()
    {
        GameTimeLeft = totalGameTime;
        Paused = true;
    }

    public void StartTimer()
    {
        Paused = false;
    }

    public void StopTimer()
    {
        Paused = true;
    }

    // Use this for initialization
    private void Start()
    {
        GameTimeLeft = totalGameTime;
        Paused = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!Paused)
        {
            GameTimeLeft -= Time.deltaTime;

            if (GameTimeLeft < 0)
            {
                GameTimeLeft = 0;
                Paused = true;
                if (Listener != null)
                {
                    Listener();
                }
            }
        }

        foreach (Text text in timeFields)
        {
            text.text = string.Format("Time: {0:00} : {1:00}", 0, Mathf.Round(GameTimeLeft));
        }
    }
}