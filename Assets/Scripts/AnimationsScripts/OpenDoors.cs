using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public Animator rightDoor;
    public Animator leftDoor;
    public GameObject otherTrigger;
    public AudioSource audioSource;

    void OnTriggerEnter(Collider other) {
        // V�rifie si le joueur est entr� dans la zone de d�tection de la porte
        if (other.CompareTag("Player")) {
            rightDoor.Play("RightDoorOpen", 0, 0.0f);
            leftDoor.Play("LeftDoorOpen", 0, 0.0f);
            audioSource.Play();
            gameObject.SetActive(false);
            otherTrigger.SetActive(false);
        }
    }

}
