using UnityEngine;

public class GSCameraTargetListener : MonoBehaviour, ITargetListener
{
    public CanvasGroup canvas;

    //private int messageCount;
    private bool canSee = false;

    public void EnterDimension()
    {
    }

    public void TargetEnteredView(string target)
    {
        //DebugText.text = string.Format("{0}: {1} has entered", messageCount++, target);
        canvas.alpha = 1f;
        //gameObject.GetComponent<CanvasGroup>().alpha = 1f;
        canSee = true;
        GameObject.Find(target).GetComponentInChildren<UIOpenCloseAnimator>().Open();
    }

    public void TargetLeftView(string target)
    {
        //DebugText.text = string.Format("{0}: {1} has left", messageCount++, target);
        canvas.alpha = 0f;

        canSee = false;
        GameObject.Find(target).GetComponentInChildren<UIOpenCloseAnimator>().Close();
    }

    public void TargetMoved(string target, Vector3 location)
    {
        //DebugText.text = string.Format("{0}: {1} is at {2}", messageCount++, target, location);
    }

    private void Start()
    {
        //messageCount = 1;
    }

    private void Update()
    {
    }
}