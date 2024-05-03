using cakeslice;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetectEndGame : MonoBehaviour
{
    private Outline outline;
    private bool isActivated = false;
    private Collider car;
    [SerializeField] private Transform carPos;
    [SerializeField] private Camera cineCam;
    [SerializeField] private GameObject transitionScreen;
    [SerializeField] private GameObject boat;
    [SerializeField] private GameObject ingameUI;
    [SerializeField] private GameObject endGameUI;
    private CameraTransition cameraTransition;
    [SerializeField] private GameObject keyToShow;

    private void Start() {
        outline = GetComponent<Outline>();
        gameObject.SetActive(false);
        cameraTransition = transitionScreen.GetComponent<CameraTransition>();
    }

    public void ActivateDetect() {
        isActivated = true;
        gameObject.SetActive(true);
    }

    public void HighlightObject() {
        outline.enabled = true;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("StolenCar") && isActivated) {
            car = other;
            cameraTransition.ChangeCamera(car.GetComponent<VehicleController>().vehicleCamera, cineCam);
            boat.GetComponent<MovingBoat>().PlaySound();
            Invoke("MoveCar", 2f);
        }
    }

    private void MoveCar() {
        car.transform.position = carPos.position;
        car.transform.rotation = carPos.rotation;
        car.GetComponent<Rigidbody>().isKinematic = true;
        ingameUI.SetActive(false);
        keyToShow.SetActive(false);
        MoveBoat();
    }

    private void MoveBoat() {
        car.transform.parent = boat.transform;
        boat.GetComponent<MovingBoat>().enableMove = true;
        Invoke("EndGame", 5f);
    }

    private void EndGame() {

        RestartGame restartGame = GameObject.Find("RestartGame").GetComponent<RestartGame>();
        restartGame.isRestarteable = true;

        TextMeshProUGUI endGameText = endGameUI.GetComponentInChildren<TextMeshProUGUI>();
        endGameText.text = "You won ! Press R to restart.";
        endGameUI.SetActive(true);
    }
}
