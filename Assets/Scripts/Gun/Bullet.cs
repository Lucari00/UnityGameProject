using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public GameObject fxSmoke;
    public GameObject bloodObject;
    public GameObject trailEffect;
    public bool isMoving = true;

    private GameObject trailEffectObject;

    private void Start() {
        //Invoke("CreateTrail", 0.1f);
        Invoke("SupprBullet", 30f); // opti suppr bullet after 30s
    }

    private void SupprBullet() {
        gameObject.SetActive(false);
    }

    private void CreateTrail() {
        //GameObject cube = gameObject.GetComponentInChildren<Transform>().gameObject;
        trailEffectObject = Instantiate(trailEffect, transform.position, Quaternion.Euler(0f, 90f, 0f)); // trouver le bon angle et la pos
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 300 || transform.position.x < -300 || transform.position.z > 300 || transform.position.z < -300) {
            gameObject.SetActive(false);
        }
        if (isMoving) {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            if (trailEffectObject != null) {
                trailEffectObject.transform.position = transform.position;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other);
        if (other.CompareTag("Player")) {
            return;
        }

        if (other.CompareTag("Enemy")) {
            Instantiate(bloodObject, transform);
            GameObject guardObject = other.transform.parent.parent.gameObject;
            Enemy enemyScript = guardObject.GetComponent<Enemy>();
            if (enemyScript != null) {
                enemyScript.Hit();
            }
        } else {
            Instantiate(fxSmoke, transform);
        }
        isMoving = false;
        
        //gameObject.SetActive(false);
    }
}
