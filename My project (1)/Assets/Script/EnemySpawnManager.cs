using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public static EnemySpawnManager instance;
    [SerializeField] private GameObject enemyPrefab;

    public static EnemySpawnManager GetInstance() 
    {
        return instance;
    }

    public void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab);
        // Initialize the new enemy accordingly...
    }
}
