using UnityEngine;
using Vuforia;

public class AutoFocus : MonoBehaviour
{
    private void Start()
    {
    }

    private void Update()
    {
        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }
}