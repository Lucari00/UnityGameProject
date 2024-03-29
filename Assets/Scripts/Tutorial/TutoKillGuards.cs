using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoKillGuards : MonoBehaviour
{
    public GameObject enemyManager;
    public List<GameObject> lights;
    private EnemyManager enemyManagerScript;
    private List<GameObject> enemies;
    private bool isFinished = false;

    private void Start() {
        enemyManagerScript = enemyManager.GetComponent<EnemyManager>();
        enemies = enemyManagerScript.SpawnGuards(3, new Vector3(-37.5f, 0f, -81f), new Vector3(0, 0, 2.0f), Quaternion.Euler(0, 90f, 0));
    }

    void Update() {
        foreach (GameObject enemy in enemies) {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if (!enemyScript.isHit) {
                return;
            }
        }
        isFinished = true;
        if (isFinished) {
            LightOff();
            isFinished = false;
        }
    }

    void LightOff() {
        lights[1].SetActive(false);
        Invoke("LightGunOff", 1f);
    }

    void LightGunOff() {
        lights[0].SetActive(false);
        gameObject.SetActive(false);
    }
}