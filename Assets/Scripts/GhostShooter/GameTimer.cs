using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float GameTimeLeft { get; private set; }
    public bool Paused { get; private set; }

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
