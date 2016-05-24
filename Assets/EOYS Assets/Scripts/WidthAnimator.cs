using System.Collections.Generic;
using UnityEngine;

public class WidthAnimator : ParameterizedAnimator
{
    public List<RectTransform> transforms;

    public override void SetParameter(float parameter)
    {
        foreach (RectTransform rectangleTransform in transforms)
        {
            rectangleTransform.localScale = new Vector3(parameter, 1.0f, 1.0f);
        }
    }
}