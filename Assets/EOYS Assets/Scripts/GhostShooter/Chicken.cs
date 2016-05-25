using UnityEngine;
using Vuforia;

public class Chicken : MonoBehaviour, ITrackableEventHandler
{
    public MinigameManager ses;

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        switch (newStatus)
        {
            case TrackableBehaviour.Status.DETECTED:
            case TrackableBehaviour.Status.TRACKED:
                ses.GameResume();
                break;

            default:
                ses.GamePause();
                break;
        }
    }

    // Use this for initialization
    private void Start()
    {
        ses.GameStart();
        ses.GamePause();
        GetComponent<TrackableBehaviour>().RegisterTrackableEventHandler(this);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}