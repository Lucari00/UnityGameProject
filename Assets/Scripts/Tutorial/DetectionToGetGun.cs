using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionToGetGun : MonoBehaviour
{
    public GameObject lightGun;
    public GameObject lightGuards;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            lightGun.SetActive(true);
            Invoke("LightGuards", 0.5f);
            gameObject.SetActive(false);
        }
    }

    void LightGuards() {
        lightGuards.SetActive(true);
    }
}
