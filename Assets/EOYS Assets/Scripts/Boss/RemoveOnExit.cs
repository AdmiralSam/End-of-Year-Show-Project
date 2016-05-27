using UnityEngine;

public class RemoveOnExit : MonoBehaviour
{
    public Vector3 MinimumCorner;
    public Vector3 MaximumCorner;

    private void Update()
    {
        Vector3 position = transform.localPosition;
        if (position.x < MinimumCorner.x || position.x > MaximumCorner.x || position.y < MinimumCorner.y || position.y > MaximumCorner.y || position.z < MinimumCorner.z || position.z > MaximumCorner.z)
        {
            Destroy(gameObject);
        }
    }
}