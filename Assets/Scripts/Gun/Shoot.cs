using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject bulletObject;
    public GameObject gun;
    public GameObject fxSmoke;
    public KeyCode shootKey = KeyCode.Mouse0;
    public AudioSource audioSource;
    public Transform characterOrientation;
    public float shootCooldown;
    private bool readyToShoot;
    public bool hasGun;
    public bool isPlayer;

    public Transform orientation;

    private void Start() {
        readyToShoot = true;
        if (isPlayer) {
            hasGun = true; // à changer quand on pourra recup l'arme
        } else {
            hasGun = true;
        }
    }

    private void getInput() {
        if (Input.GetKey(shootKey) && readyToShoot && hasGun) {
            readyToShoot = false;
            Fire();
            Invoke("ResetShoot", shootCooldown);
        }
    }

    private void ResetShoot() {
        readyToShoot = true;
    }

    private void Fire() {
        Quaternion rotation = Quaternion.Euler(-8f, characterOrientation.localRotation.eulerAngles.y - 0.2f, characterOrientation.localRotation.eulerAngles.z + 90);
        Instantiate(bulletObject, gun.transform.position, rotation);
        Instantiate(fxSmoke, gun.transform.position + new Vector3(0f, 0.05f, 0f), rotation);
        PlaySound();
    }

    // Update is called once per frame
    void Update() {
        if (isPlayer) {
            getInput();
        }
    }

    void PlaySound() {
        if (audioSource != null) {
            audioSource.Play(); // Commencez à jouer le son
        }
    }
}