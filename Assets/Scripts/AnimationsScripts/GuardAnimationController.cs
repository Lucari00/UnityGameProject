using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAnimationController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        animator.SetInteger("state", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
