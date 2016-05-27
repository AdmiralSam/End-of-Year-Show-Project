using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnRandomEnemies : MonoBehaviour {

	public Transform enemyPrefab;
	public float enemyScaleMinScale;
	public float enemyMaxScale;
	public float spawnTime;

	private bool spawnEnemies;
	private float spawnTimer;

	public void Reset()
	{
		spawnEnemies = false;

		List<GameObject> spawned = new List<GameObject>();

		for (int i = 0; i < transform.childCount; i++)
		{
			spawned.Add(transform.GetChild(i).gameObject);
		}
		foreach (GameObject child in spawned)
		{
			Destroy(child);
		}

	}

	public void StartSpawningEnemies()
	{
		spawnEnemies = true;
	}

	public void StopSpawningEnemies()
	{
		spawnEnemies = false;
	}

	private void Spawn()
	{
		float enemyScale = Random.Range(enemyScaleMinScale, enemyMaxScale);
		Transform enemy = Instantiate(enemyPrefab);

		enemy.parent = transform;
		enemy.localPosition = new Vector3(Random.Range(-0.5f, 0.5f), 0f, Random.Range(-0.5f, 0.5f));
		enemy.localRotation = Quaternion.identity;
		enemy.localScale = new Vector3(enemyScale, enemyScale, enemyScale);
		enemy.gameObject.SetActive(true);
	}

	// Use this for initialization
	private void Start()
	{
		spawnTimer = spawnTime;
		spawnEnemies = false;
	}

	// Update is called once per frame
	private void Update()
	{
		if (spawnEnemies)
		{
			spawnTimer -= Time.deltaTime;
			if (spawnTimer <= 0.0f)
			{
				spawnTimer = spawnTime;
				Spawn();
			}
		}
	}
}
