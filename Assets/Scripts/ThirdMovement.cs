using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdMovement : MonoBehaviour
{
    [Header("Animation")]
    private Animator animator;
    [Header("Movement")]
    public float moveSpeed = 1f;
    public float groundDrag = 6f;
    public Transform orientation;
    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask groundMask;
    bool isGrounded;

    float horizontalMovement;
    float verticalMovement;
    Vector3 moveDirection;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update() {
        MyInput();
        isGrounded = Physics.Raycast(transform.position, Vector3.down, (playerHeight * 0.5f) + 0.2f, groundMask);

        if (isGrounded) {
            rb.drag = groundDrag;
        }
        else {
            rb.drag = 0;
        }

        animator.SetFloat("Vertical", verticalMovement);
        animator.SetFloat("Horizontal", horizontalMovement);
    }

    private void MyInput() {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer() {
        moveDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;
        moveDirection.y = 0;

        rb.AddForce(moveDirection.normalized * moveSpeed *15f, ForceMode.Force);
    }

    private void FixedUpdate() {
        MovePlayer();
        // horizontalMovement = Input.GetAxisRaw("Horizontal");
        // verticalMovement = Input.GetAxisRaw("Vertical");

        // moveDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;
        // moveDirection.y = 0;

        // rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
    }
}
