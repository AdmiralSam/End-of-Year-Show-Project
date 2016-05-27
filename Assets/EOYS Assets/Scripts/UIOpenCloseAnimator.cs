using System.Collections.Generic;
using UnityEngine;

public class UIOpenCloseAnimator : MonoBehaviour
{
    public float AnimationTime;
    public List<ParameterizedAnimator> animators;
    public OnCloseListener OnClose;
    public bool StartActive;
    private State currentState;
    private float currentTime;

    public delegate void OnCloseListener();

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
}