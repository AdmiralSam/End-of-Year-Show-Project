using UnityEngine;

public class Testerino : MonoBehaviour {
    public BossHealthBar ses;
    private float timeElapsed;
	void Start () {
        timeElapsed = 0.0f;
	}
	
	void Update () {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > 1)
        {
            ses.TakeDamage(10);
            timeElapsed = 0.0f;
        }
	}
}
