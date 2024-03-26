using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{

    private Animator mAnimator;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        Debug.Log("here");
        Normal();
        
    }

    private void Normal() {
        mAnimator.SetTrigger("LeftToRight");
        mAnimator.SetTrigger("LeftToRight");
        Debug.Log("la");
        Invoke("Reverse", 10f);
    }

    private void Reverse() {
        mAnimator.SetTrigger("RightToLeft");
        Debug.Log("yo");
        Invoke("Normal", 10f);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
