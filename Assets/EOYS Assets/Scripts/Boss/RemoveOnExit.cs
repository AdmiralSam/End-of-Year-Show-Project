using UnityEngine;

public class RemoveOnExit : MonoBehaviour
{
    public Vector3 MaximumCorner;
    public Vector3 MinimumCorner;
    public delegate void Recycle(VelocityMove bullet);
    public Recycle Listener { private get; set; }

    private void Update()
    {
        Vector3 position = transform.localPosition;
        if (position.x < MinimumCorner.x || position.x > MaximumCorner.x || position.y < MinimumCorner.y || position.y > MaximumCorner.y || position.z < MinimumCorner.z || position.z > MaximumCorner.z)
        {
            if (Listener != null)
            {
                Listener(GetComponent<VelocityMove>());
            }
        }
    }
}