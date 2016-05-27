using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public Transform[] enemyPrefabs;
    public float enemyScale;
    public GameTimer gameTimer;
    public Transform miniGameTransform;
    public float spawnTime;
    private bool spawnEnemies;
    private float spawnTimer;

    public void Reset()
    {
        spawnEnemies = false;
        List<GameObject> spawned = new List<GameObject>();

        for (int i = 0; i < miniGameTransform.childCount; i++)
        {
            spawned.Add(miniGameTransform.GetChild(i).gameObject);
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
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Transform enemy = Instantiate(enemyPrefabs[enemyIndex]);

        enemy.parent = miniGameTransform;
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