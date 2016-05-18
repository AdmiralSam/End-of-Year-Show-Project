using UnityEngine;
using System.Collections;
using Vuforia;

public class Test : MonoBehaviour {
    public Transform camera;
	// Use this for initialization
	void Start () {
        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 toCamera = camera.position - transform.position;
        toCamera.Normalize();
        if (toCamera.y < 1 / Mathf.Sqrt(2))
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -90));
        } else
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
	}
}
