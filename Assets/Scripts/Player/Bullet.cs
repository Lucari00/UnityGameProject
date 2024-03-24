using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public GameObject fxSmoke;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 300 || transform.position.x < -300 || transform.position.z > 300 || transform.position.z < -300) {
            gameObject.SetActive(false);
        }
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other);
        if (other.CompareTag("Enemy")) {
            Debug.Log("kill enemy");
        } else if (other.CompareTag("Wall")) {
            Debug.Log("here");
        }
        gameObject.SetActive(false);
        Instantiate(fxSmoke, transform);
    }
}
