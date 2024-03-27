using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject bulletObject;
    public GameObject gun;
    public GameObject fxSmoke;
    public KeyCode shootKey = KeyCode.Mouse0;
    public AudioSource audioSource;
    public float shootCooldown;
    private bool readyToShoot;
    private bool hasGun;
    public Camera cameraJoueur;

    public Transform orientation;

    private void Start() {
        readyToShoot = true;
        hasGun = true;
    }

    private void getInput() {
        if (Input.GetKey(shootKey) && readyToShoot && hasGun) {
            readyToShoot=false;
            Shoot();
            Invoke("ResetShoot", shootCooldown);
        }
    }

    private void ResetShoot() {
        readyToShoot = true;
    }

    private void Shoot() {
        //Vector3 shootDirection = orientation.forward; // Get the forward direction of the orientation
        //Quaternion rotation = Quaternion.LookRotation(shootDirection);
        //rotation.eulerAngles = new Vector3(90f, rotation.eulerAngles.y, rotation.eulerAngles.z); // Force X axis to 90 degrees

        Vector3 positionCamera = transform.position;
        Vector3 positionGun = gun.transform.position;
        Vector3 vecteurMilieuVue = positionCamera + gun.transform.forward * Vector3.Distance(positionCamera, positionGun) / 2;
        Quaternion rotationObjetVersMilieuVue = Quaternion.LookRotation(vecteurMilieuVue - positionGun);


        Instantiate(bulletObject, gun.transform.position, rotationObjetVersMilieuVue);
        Instantiate(fxSmoke, gun.transform.position + new Vector3(0f, 0.05f, 0f), rotationObjetVersMilieuVue);
        PlaySound();
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }

    void PlaySound() {
        if (audioSource != null) {
            audioSource.Play(); // Commencez à jouer le son
        }
    }
}
