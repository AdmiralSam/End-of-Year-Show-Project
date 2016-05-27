using System.Collections.Generic;
using UnityEngine;

public class MinigameOpenCloseAnimator : MonoBehaviour
{
    public float AnimationTime;
    public List<ParameterizedAnimator> animators;
    private State currentState;
    private float currentTime;

    private enum State { Open, Closed, Opening, Closing }

    public void Close()
    {
        currentState = State.Closing;
    }

    public void Open()
    {
        currentState = State.Opening;
    }

    private void Start()
    {
        currentState = State.Closed;
        currentTime = 0.0f;
    }

    private void Update()
    {
        switch (currentState)
        {
            case State.Opening:
                currentTime += Time.deltaTime;
                if (currentTime > AnimationTime)
                {
                    currentTime = AnimationTime;
                    currentState = State.Open;
                }
                break;

            case State.Closing:
                currentTime -= Time.deltaTime;
                if (currentTime < 0.0f)
                {
                    currentTime = 0.0f;
                    currentState = State.Closed;
                }
                break;
        }
        foreach (ParameterizedAnimator animator in animators)
        {
            animator.SetParameter(currentTime / AnimationTime);
        }
    }
}