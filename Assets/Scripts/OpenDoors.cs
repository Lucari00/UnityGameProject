using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public Animator rightDoor;
    public Animator leftDoor;

    void Start() {
    }

    void Update() {
    }

    void OnTriggerEnter(Collider other) {
        // Vérifie si le joueur est entré dans la zone de détection de la porte
        if (other.CompareTag("Player")) {
            Debug.Log("open");
            rightDoor.Play("RightDoorOpen", 0, 0.0f);
            leftDoor.Play("LeftDoorOpen", 0, 0.0f);
            gameObject.SetActive(false);
        }
    }

    /*void OnTriggerExit(Collider other) {
        // Vérifie si le joueur est sorti de la zone de détection de la porte
        if (other.CompareTag("Player")) {
            playerInRange = false;
        }
    }*/
}
