using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public Animator rightDoor;
    public Animator leftDoor;
    public GameObject otherTrigger;

    void OnTriggerEnter(Collider other) {
        // Vérifie si le joueur est entré dans la zone de détection de la porte
        if (other.CompareTag("Player")) {
            rightDoor.Play("RightDoorOpen", 0, 0.0f);
            leftDoor.Play("LeftDoorOpen", 0, 0.0f);
            gameObject.SetActive(false);
            otherTrigger.SetActive(false);
        }
    }

}
