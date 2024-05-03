using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGarageDoors : MonoBehaviour
{
    private Animator animator;

    public float timeToOpenDoor;

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Invoke("OpenDoor", timeToOpenDoor);
    }

    void OpenDoor() {
        PlaySound();
        animator.Play("GarageDoorAnimation");
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isOpening && isReady) {
        //    isOpening = true; // Marque que la porte est en train de s'ouvrir
        //    StartCoroutine(OpenDoorCoroutine()); // Démarre la coroutine pour ouvrir progressivement la porte
        //}
    }

    void PlaySound() {
        if (audioSource != null) {
            audioSource.Play(); // Commencez à jouer le son
        }
    }

    void StopSound() {
        if (audioSource != null && audioSource.isPlaying) {
            audioSource.Stop(); // Arrêtez de jouer le son si c'est en cours de lecture
        }
    }

}
