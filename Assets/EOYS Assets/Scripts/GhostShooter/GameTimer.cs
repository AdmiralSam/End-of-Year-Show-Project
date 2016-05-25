using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float GameTimeLeft { get; private set; }
    public bool Paused { get; private set; }
    public Text[] timeFields;

    // Use this for initialization
    void Start() {
        GameTimeLeft = 59.0f;
        Paused = true;
    }

    // Update is called once per frame
    void Update() {

        if (!Paused)
        {
            GameTimeLeft -= Time.deltaTime;

            if (GameTimeLeft < 0)
            {
                GameTimeLeft = 0;
            }
        }
        foreach (Text text in timeFields)
        {
            text.text = string.Format("Time: {0:00} : {1:00}", 0, Mathf.Round(GameTimeLeft));
        }
    }

    public void StartTimer()
    {
        Paused = false;
    }

    public void StopTimer()
    {
        Paused = true;
    }

    public void ResetTimer()
    {
        GameTimeLeft = 59.0f;
        Paused = true;
    }
}
