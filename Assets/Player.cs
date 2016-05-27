using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Transform Probe;
	public Transform Probe2;

	private bool ballMoving;

	public Vector3 GetNormal()
	{
		return Probe2.localPosition - Probe.localPosition;
	}

	private void Start()
	{
		ballMoving = false;
	}

	private void Update()
	{
		if (ballMoving) 
		{
			Probe.position = Vector3.zero;
			Probe2.position = Vector3.forward;

			Vector3 local = Probe.localPosition;
			local.x = Mathf.Clamp (local.x, -0.5f, 0.5f);
			local.y = 1.0f;
			local.z = Mathf.Clamp (local.z, -0.5f, 0.5f);
			transform.localPosition = local;
			//transform.localPosition = Vector3.Lerp(transform.localPosition, local, 0.5f);
			Quaternion rotation = Quaternion.identity;
			rotation.SetFromToRotation (Vector3.down, GetNormal ());
			transform.localRotation = rotation;
		}
	}
		
	public void StartMoving ()
	{
		ballMoving = true;
	}

	public void StopMoving ()
	{
		ballMoving = false;
	}

	public void Reset()
	{
		//transform.localPosition = new Vector3 ();
	}

}
