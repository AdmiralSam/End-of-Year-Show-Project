using UnityEngine;
using UnityEngine.UI;

public class CameraTargetListener : MonoBehaviour, ITargetListener
{
    public MinigameController controller;
    public Text DebugText;
    public float MaximumAngle;
    public float MaximumDistance;
    private bool inRange;

    public void EnterDimension()
    {
        controller.EnteredDimension();
    }

    public void TargetEnteredView(string target)
    {
    }

    public void TargetLeftView(string target)
    {
        if (inRange)
        {
            controller.LeftTarget(target);
            inRange = false;
        }
    }

    public void TargetMoved(string target, Vector3 location)
    {
        float angle = Vector3.Angle(location, Vector3.forward);
        bool withinDistance = location.sqrMagnitude < MaximumDistance * MaximumDistance;
        bool withinAngle = angle < MaximumAngle;
        if (withinDistance && withinAngle)
        {
            if (!inRange)
            {
                controller.EnteredTarget(target);
                inRange = true;
            }
        }
        else
        {
            if (inRange)
            {
                controller.LeftTarget(target);
                inRange = false;
            }
        }
    }

    private void Start()
    {
    }

    private void Update()
    {
    }
}