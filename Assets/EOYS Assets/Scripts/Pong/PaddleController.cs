using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public Transform Probe;
    public Transform Probe2;

    public Vector3 GetNormal()
    {
        return Probe2.localPosition - Probe.localPosition;
    }

    private void Start()
    {
    }

    private void Update()
    {
        Probe.position = Vector3.zero;
        Probe2.position = Vector3.forward;

        Vector3 local = Probe.localPosition;
        local.x = Mathf.Clamp(local.x, -0.5f, 0.5f);
        local.y = 1.0f;
        local.z = Mathf.Clamp(local.z, -0.5f, 0.5f);
		transform.localPosition = local;
		//transform.localPosition = Vector3.Lerp(transform.localPosition, local, 0.5f);
        Quaternion rotation = Quaternion.identity;
        rotation.SetFromToRotation(Vector3.down, GetNormal());
        transform.localRotation = rotation;
    }
}