using UnityEngine;
using UnityEngine.UI;

public class CameraTargetListener : MonoBehaviour, ITargetListener
{
    public Text DebugText;
    private int messageCount;

    public void TargetEnteredView(string target)
    {
        DebugText.text = string.Format("{0}: {1} has entered", messageCount++, target);
        GameObject.Find(target).GetComponentInChildren<UIOpenCloseAnimator>().Open();
    }

    public void TargetLeftView(string target)
    {
        DebugText.text = string.Format("{0}: {1} has left", messageCount++, target);
        GameObject.Find(target).GetComponentInChildren<UIOpenCloseAnimator>().Close();
    }

    public void TargetMoved(string target, Vector3 location)
    {
        DebugText.text = string.Format("{0}: {1} is at {2}", messageCount++, target, location);
    }

    public void EnterDimension()
    {
    }

    private void Start()
    {
        messageCount = 1;
    }

    private void Update()
    {
    }
}