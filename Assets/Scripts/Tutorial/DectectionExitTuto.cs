using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DectectionExitTuto : AbstractTutoClass
{
    [SerializeField] private GameObject transitionScreen;
    [SerializeField] private Camera cineCam;
    [SerializeField] private GameObject directionArrow;
    private CameraTransition cameraTransition;
    private GameObject missionInformation;

    private void Start() {
        missionInformation = GameObject.Find("MissionInformation");
        cameraTransition = transitionScreen.GetComponent<CameraTransition>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Vehicle")) {
            isFinish = true;
            Camera vehicleCam = other.GetComponent<VehicleController>().vehicleCamera;
            cameraTransition.ChangeCamera(vehicleCam, cineCam);
            directionArrow.SetActive(false);
            missionInformation.SetActive(false);
        }
    }
}
