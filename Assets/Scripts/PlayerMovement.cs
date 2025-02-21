using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private Vector3 rotateY;
    
    // Movement settings 
    // public float moveSpeed = 1f;
    // public float rotateSpeed = 1f;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        // {
        //     animator.SetTrigger("Moving");
        // } // else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) {
        // //     animator.SetTrigger("Strafing");
        // // }
        //  else if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     animator.SetTrigger("Jump");
        // } else if (Input.GetMouseButtonDown(0))
        // {
        //     animator.SetTrigger("Attack");
        // } else
        // {
        //     animator.SetTrigger("Idle");
        // }

        // rb.MovePosition(rb.position + transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        // if (Input.GetAxis("Vertical") != 0)
        // {
        //     if (Input.GetAxis("Horizontal") > 0)
        //     {
        //         rotateY = new Vector3(0, rotateSpeed * Time.deltaTime, 0);
        //     } else if (Input.GetAxis("Horizontal") < 0)
        //     {
        //         rotateY = new Vector3(0, -rotateSpeed * Time.deltaTime, 0);
        //     }
        //     rb.MoveRotation(rb.rotation * Quaternion.Euler(rotateY));
        // }
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
    }
}
