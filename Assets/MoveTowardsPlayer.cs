using UnityEngine;
using System.Collections;

public class MoveTowardsPlayer : MonoBehaviour {
	
	public GameTimer gameTimer;
	public float MinSpeed;
	public float MaxSpeed;

	private float wallPosition;

	// Use this for initialization
	private void Start()
	{
		wallPosition = 1.0f;
	}

	// Update is called once per frame
	private void Update()
	{
		if (!gameTimer.Paused)
		{
			float moveHorizontal = Random.Range(-0.0015f, 0.0015f);
			float moveVertical = Random.Range(-0.0015f, 0.0015f);

			transform.localPosition += new Vector3(moveHorizontal, Random.Range(MinSpeed, MaxSpeed), moveVertical);

			if (transform.localPosition.y >= wallPosition)
			{
				Destroy(gameObject);
			}
		}
	}
}
