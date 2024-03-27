using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator animator;
    PlayerMovement playerMovement;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = Player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = playerMovement.GetPlayerSpeed();
        animator.SetFloat("speed", moveSpeed);
        //Debug.Log("MS" + moveSpeed);
        //Debug.Log("speed" + animator.GetFloat("speed"));
    }
}
