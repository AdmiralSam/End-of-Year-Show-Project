using UnityEngine;
using System.Collections;

public class RandomMaterialColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 255) / 255.0f, Random.Range(0, 255) / 255.0f, Random.Range(0, 255) / 255.0f, 1F);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
