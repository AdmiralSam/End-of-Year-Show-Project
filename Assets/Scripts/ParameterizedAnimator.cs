using UnityEngine;

public abstract class ParameterizedAnimator : MonoBehaviour, IParameterized
{
    public abstract void SetParameter(float parameter);
}