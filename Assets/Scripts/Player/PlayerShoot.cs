using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject bulletObject;
    public GameObject gun;
    public KeyCode shootKey = KeyCode.Mouse0;
    public float shootCooldown;
    private bool readyToShoot;
    private bool hasGun;

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
        Vector3 shootDirection = orientation.forward; // Get the forward direction of the orientation
        Quaternion rotation = Quaternion.LookRotation(shootDirection);
        rotation.eulerAngles = new Vector3(90f, rotation.eulerAngles.y, rotation.eulerAngles.z); // Force X axis to 90 degrees
        GameObject bullet = Instantiate(bulletObject, gun.transform.position, rotation);
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }
}
