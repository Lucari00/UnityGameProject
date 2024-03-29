using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class DetectionShoot : MonoBehaviour
{
    public GameObject textKey;
    public GameObject playerObject;
    public GameObject propGunObject;
    public GameObject characterObject;
    public GameObject crosshairObject;
    public KeyCode keyGet = KeyCode.E;
    private bool isInRange;
    private Shoot shootScript;

    private void Start() {
        textKey.SetActive(false);
        shootScript = playerObject.GetComponent<Shoot>();
    }

    private void Update() {
        GetInput();
    }

    private void GetInput() {
        if (Input.GetKey(keyGet) && isInRange) {
            TakeGun();
        }
    }

    private void TakeGun() {
        shootScript.hasGun = true;
        propGunObject.SetActive(false);
        textKey.SetActive(false);
        characterObject.SetActive(true);
        crosshairObject.SetActive(true);
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other) {
        // Vérifie si le joueur est entré dans la zone de détection de la porte
        if (other.CompareTag("Player")) {
            textKey.SetActive(true);
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            textKey.SetActive(false);
            isInRange = false;
        }
    }
}
