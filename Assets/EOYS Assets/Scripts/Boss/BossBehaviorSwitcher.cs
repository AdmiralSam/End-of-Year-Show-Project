using UnityEngine;

public class BossBehaviorSwitcher : MonoBehaviour
{
    public BossHealthBar healthBar;
    private ConeShootBehavior coneShootBehavior;
    private int currentStage;
    private SimpleShootBehavior simpleShootBehavior;
    private StarCircleBehavior starCircleBehavior;

    public delegate void OnBossDeath();
    public OnBossDeath Listener { private get; set; }

    public void Activate()
    {
        currentStage = 1;
        simpleShootBehavior.Activate();
    }

    public void Pause()
    {
        switch (currentStage)
        {
            case 1: simpleShootBehavior.Pause(); break;
            case 2: coneShootBehavior.Pause(); break;
            case 3: starCircleBehavior.Pause(); break;
        }
    }

    public void Reset()
    {
        simpleShootBehavior.Reset();
        coneShootBehavior.Reset();
        starCircleBehavior.Reset();
        healthBar.Reset();
    }

    public void ResetPosition()
    {
        transform.localPosition = new Vector3(0.0f, 0.1f, 0.0f);
    }

    public void Resume()
    {
        switch (currentStage)
        {
            case 1: simpleShootBehavior.Resume(); break;
            case 2: coneShootBehavior.Resume(); break;
            case 3: starCircleBehavior.Resume(); break;
        }
    }

    private void StageEnded(int stage)
    {
        switch (stage)
        {
            case 1:
                simpleShootBehavior.Reset();
                coneShootBehavior.Activate();
                currentStage = 2;
                break;

            case 2:
                coneShootBehavior.Reset();
                starCircleBehavior.Activate();
                currentStage = 3;
                break;

            case 3:
                starCircleBehavior.Reset();
                if (Listener != null)
                {
                    Listener();
                }
                break;
        }
    }

    private void Start()
    {
        healthBar.Listener = StageEnded;
        simpleShootBehavior = GetComponent<SimpleShootBehavior>();
        coneShootBehavior = GetComponent<ConeShootBehavior>();
        starCircleBehavior = GetComponent<StarCircleBehavior>();
    }
}