using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {

	public delegate void OnPlayerDied();
	public OnPlayerDied Listener { private get; set; }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter(Collider other)
	{
		if (name.Contains ("Player")) {
			if (Listener != null) {
				Listener ();
			}
		} 
		else 
		{
			Destroy (gameObject);
		}
	}

}
