using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject[] cameras;
    int currentCameraIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchCameras() {
        cameras[currentCameraIndex].SetActive(false);
        currentCameraIndex++;
        currentCameraIndex %= cameras.Length;
        cameras[currentCameraIndex].SetActive(true);
    }
}
