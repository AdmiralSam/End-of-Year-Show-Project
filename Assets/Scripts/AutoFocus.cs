using UnityEngine;
using Vuforia;

public class AutoFocus : MonoBehaviour
{
    private void Start()
    {
        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }

    private void Update()
    {
    }
}