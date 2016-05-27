using UnityEngine;
using Vuforia;

public class Chicken : MonoBehaviour, ITrackableEventHandler
{
    private float weed;
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
        weed = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (weed >= 0)
        weed += Time.deltaTime;
        if (weed > 1)
        {
            ses.GameStart();
            ses.GamePause();
            GetComponent<TrackableBehaviour>().RegisterTrackableEventHandler(this);
            weed = -1;
        }
    }
}