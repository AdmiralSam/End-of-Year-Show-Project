using UnityEngine;
using Vuforia;

public class TargetNotifier : MonoBehaviour, ITrackableEventHandler
{
    public CameraTargetListener listener;

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        switch (newStatus)
        {
            case TrackableBehaviour.Status.DETECTED:
            case TrackableBehaviour.Status.TRACKED:
                listener.TargetEnteredView(transform.name);
                break;

            default:
                listener.TargetLeftView(transform.name);
                break;
        }
    }

    private void Start()
    {
        GetComponent<TrackableBehaviour>().RegisterTrackableEventHandler(this);
    }

    private void Update()
    {
    }
}