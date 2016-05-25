using System.Collections.Generic;
using UnityEngine;

public class UIOpenCloseAnimator : MonoBehaviour
{
    public float AnimationTime;
    public List<ParameterizedAnimator> animators;
    private float currentTime;
    private State currentState;

    public bool StartActive;

    public delegate void OnCloseListener();

    public OnCloseListener OnClose;

    private enum State { Open, Closed, Opening, Closing }

    private void Start()
    {
        currentState = State.Closed;
        currentTime = 0.0f;
        gameObject.SetActive(StartActive);
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
                    if (OnClose != null)
                    {
                        OnClose();
                    }
                }
                break;
        }
        foreach (ParameterizedAnimator animator in animators)
        {
            animator.SetParameter(currentTime / AnimationTime);
        }
    }

    public void Open()
    {
        currentState = State.Opening;
    }

    public void Close()
    {
        currentState = State.Closing;
    }
}