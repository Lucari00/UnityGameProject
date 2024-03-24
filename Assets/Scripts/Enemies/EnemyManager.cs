using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyManager : MonoBehaviour
{
    
    public GameObject enemy;
    public Vector3 spawnPoint;

    void Start()
    {
        for(int i = 0; i < 3; i++) {
            Instantiate(enemy, spawnPoint + new Vector3(0, 0, i * 2.0f), Quaternion.Euler(0, 90f, 0));
        }
    }
}
