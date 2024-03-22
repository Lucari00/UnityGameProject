using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGarageDoors : MonoBehaviour
{

    private float doorSpeed = 1f;
    private float doorOpenHeight = 3.57f;

    private bool isOpening = false;
    private bool isReady = false;

    public float timeToOpenDoor;

    public AudioSource audioSource;
    //private float soundStartTimestamp = 81;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("doorIsReady", timeToOpenDoor);
    }

    void doorIsReady() {
        isReady = true;
    }

    IEnumerator OpenDoorCoroutine() {
        // Calcule la hauteur actuelle de la porte de garage
        float initialHeight = transform.position.y;
        float targetHeight = initialHeight + doorOpenHeight;

        PlaySound();
        // Ouvre progressivement la porte de garage jusqu'à la hauteur désirée
        while (transform.position.y < targetHeight) {
            float newY = Mathf.MoveTowards(transform.position.y, targetHeight, doorSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            yield return null; // Attend la prochaine frame pour continuer l'instruction
        }

        StopSound();

        isOpening = false; // Marque que l'ouverture de la porte est terminée
        isReady = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (!isOpening && isReady) {
            isOpening = true; // Marque que la porte est en train de s'ouvrir
            StartCoroutine(OpenDoorCoroutine()); // Démarre la coroutine pour ouvrir progressivement la porte
        }
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
