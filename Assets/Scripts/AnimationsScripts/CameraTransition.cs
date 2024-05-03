using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    public Camera currentCamera;
    public Camera nextCamera;

    private Animator transitionAnimator;

    void Start() {
        transitionAnimator = GetComponent<Animator>();
    }

    public void ChangeCamera(Camera current, Camera next) {
        currentCamera = current;
        nextCamera = next;
        transitionAnimator.SetTrigger("Change");
    }

    void ApplyChange() {
        currentCamera.gameObject.SetActive(false);
        nextCamera.gameObject.SetActive(true);
    }
}
