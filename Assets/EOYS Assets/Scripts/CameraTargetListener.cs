using UnityEngine;
using UnityEngine.UI;

public class CameraTargetListener : MonoBehaviour, ITargetListener
{
    public Text DebugText;
    public MinigameController controller;
    public float MaximumDistance;
    public float MaximumAngle;
    private bool inRange;

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
        DebugText.text = "Angle: " + angle;
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

    public void EnterDimension()
    {
        controller.EnteredDimension();
    }

    private void Start()
    {
    }

    private void Update()
    {
    }
}