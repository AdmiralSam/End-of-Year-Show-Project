using UnityEngine;

public class Testerino : MonoBehaviour
{
    public BossHealthBar ses;
    private float damage;
    private float timeElapsed;

    private void Start()
    {
        timeElapsed = 0.0f;
        damage = 0.0f;
    }

    private void Update()
    {
        if (timeElapsed >= 0.0f)
        {
            timeElapsed += Time.deltaTime;
        }
        else
        {
            damage += Time.deltaTime;
            if (damage > 0.5f)
            {
                damage = 0.0f;
                ses.TakeDamage(2);
            }
        }
        if (timeElapsed > 1.0f)
        {
            timeElapsed = -1.0f;
            GetComponent<BossBehaviorSwitcher>().Activate();
        }
    }
}