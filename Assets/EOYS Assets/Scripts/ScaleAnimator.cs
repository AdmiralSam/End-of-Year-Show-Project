using UnityEngine;

public class ScaleAnimator : ParameterizedAnimator
{
    public Transform objectToScale;

    public override void SetParameter(float parameter)
    {
        objectToScale.localScale = new Vector3(parameter + 0.00001f, parameter + 0.00001f, parameter + 0.00001f);
    }
}