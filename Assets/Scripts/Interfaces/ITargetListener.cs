using UnityEngine;

public interface ITargetListener
{
    void TargetEnteredView(string target);

    void TargetLeftView(string target);

    void TargetMoved(string target, Vector3 cameraPosition);
}