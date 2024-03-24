using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed;
    public float maxSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode shiftKey = KeyCode.LeftShift;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask groundMask;
    bool isGrounded;

    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
    }

    private void GetInput() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey(jumpKey) && isGrounded && readyToJump) {
            readyToJump = false;
            maxSpeed = moveSpeed;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        } else if (Input.GetKey(shiftKey) && isGrounded) {
            maxSpeed = moveSpeed + 3; 
        } else {
            maxSpeed = moveSpeed;
        }
    }

    private void MovePlayer() {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (isGrounded) {
            rb.AddForce(moveDirection.normalized * maxSpeed * 10f, ForceMode.Force);
        } else if (!isGrounded) {
            rb.AddForce(moveDirection.normalized * maxSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    void FixedUpdate() {
        MovePlayer();
    }

    private void Update() {
        //Ground check
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight / 2 + 0.5f, groundMask);

        GetInput();
        SpeedControl();

        // Ground drag

        if (isGrounded) {
            rb.drag = groundDrag;
        } else {
            rb.drag = 0;
        }
    }

    private void SpeedControl() {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if (flatVel.magnitude > maxSpeed) {
            Vector3 limitedVel = flatVel.normalized * maxSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump() {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump() {
        readyToJump = true;
    }
}
