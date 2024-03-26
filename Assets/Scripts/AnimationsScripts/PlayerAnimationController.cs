using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W)) {
            animator.SetInteger("state", 2);
        } else if (Input.GetKey(KeyCode.W)) {
            animator.SetInteger("state", 1);
        } else {
            animator.SetInteger("state", 0);
        }
        //Debug.Log(animator.GetInteger("state"));
    }
}
