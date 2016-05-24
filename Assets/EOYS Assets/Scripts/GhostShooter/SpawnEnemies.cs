﻿using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameTimer gameTimer;
    public Transform[] enemyPrefabs;
    public float enemyScale;
    public float spawnTime;
    public Transform miniGameTransform;

    private float spawnTimer;

    // Use this for initialization
    private void Start()
    {
        spawnTimer = 0.0f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!gameTimer.Paused && gameTimer.GameTimeLeft > 0)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer > spawnTime)
            {
                spawnTimer = 0.0f;
                Spawn();
            }
        }
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
}