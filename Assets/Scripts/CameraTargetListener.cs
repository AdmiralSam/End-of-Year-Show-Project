using System;
using UnityEngine;
using UnityEngine.UI;

public class CameraTargetListener : MonoBehaviour, ITargetListener
{
    private int messageCount;
    public Text test;

    public void TargetEnteredView(string target)
    {
        test.text = string.Format("{0}: {1} has entered", messageCount++, target);
    }

    public void TargetLeftView(string target)
    {
        test.text = string.Format("{0}: {1} has left", messageCount++, target);
    }

    public void TargetMoved(string target, Vector3 cameraPosition)
    {
        throw new NotImplementedException();
    }

    private void Start()
    {
        messageCount = 1;
    }

    private void Update()
    {
    }
}