using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyManager : MonoBehaviour
{
    
    public GameObject enemy;

    public List<GameObject> SpawnGuards(int n, Vector3 spawnPoint, Vector3 distanceInBetween, Quaternion rotation) {
        List<GameObject> enemies = new List<GameObject>();
        for (int i = 0; i < n; i++) {
            GameObject enemyObject = Instantiate(enemy, spawnPoint + i * distanceInBetween, rotation);
            enemies.Add(enemyObject);
        }
        return enemies;
    }
}
