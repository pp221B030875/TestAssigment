using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] enemyPrefabs;
    private int randomPoint, randomEnemy;

    [SerializeField] private float timerBeforeSpawn = 10.0f;

    private void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    private IEnumerator spawnEnemy()
    {
        yield return new WaitForSeconds(timerBeforeSpawn);
        randomPoint = Random.Range(0,spawnPoints.Length);
        randomEnemy = Random.Range(0,enemyPrefabs.Length);
        Instantiate(enemyPrefabs[randomEnemy], spawnPoints[randomPoint].position, Quaternion.identity);
        StartCoroutine(spawnEnemy());
    }
}
