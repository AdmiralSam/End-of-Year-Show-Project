using System;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class CameraTargetListener : MonoBehaviour, ITargetListener
{
    public Text test;
    private int messageCount;

    public void TargetEnteredView(string target)
    {
        test.text = string.Format("{0}: {1} has entered", messageCount++, target);
    }

    public void TargetLeftView(string target)
    {
        test.text = string.Format("{0}: {1} has left", messageCount++, target);
    }

    public void TargetMoved(string target, Vector3 location)
    {
        test.text = string.Format("{0}: {1} is at {2}", messageCount, target, location);
    }

    private void Start()
    {
        messageCount = 1;
    }

    private void Update()
    {
    }
}