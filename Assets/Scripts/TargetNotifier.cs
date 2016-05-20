using UnityEngine;
using Vuforia;

public class TargetNotifier : MonoBehaviour, ITrackableEventHandler
{
    public CameraTargetListener listener;
    private bool active;

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        switch (newStatus)
        {
            case TrackableBehaviour.Status.DETECTED:
            case TrackableBehaviour.Status.TRACKED:
                listener.TargetEnteredView(transform.name);
                active = true;
                break;

            default:
                listener.TargetLeftView(transform.name);
                active = false;
                break;
        }
    }

    private void Start()
    {
        GetComponent<TrackableBehaviour>().RegisterTrackableEventHandler(this);
        active = false;
    }

    private void Update()
    {
        if (active)
        {
            listener.TargetMoved(transform.name, new Vector3(-transform.position.x, -transform.position.y, transform.position.z));
        }
    }
}