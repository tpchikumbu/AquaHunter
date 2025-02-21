using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCamera : MonoBehaviour
{
    public Transform player;
    public Transform orientation;
    public Transform playerObj;
    public Transform lookAtObj;
    public Rigidbody rb;

    public float rotationSpeed = 5;

    public enum CameraStyle
    {
        FirstPerson,
        ThirdPerson
    }

    public CameraStyle currentStyle = CameraStyle.ThirdPerson;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate orientation
        Vector3 viewDirection = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDirection.normalized;

        // Rotate player
        if (currentStyle == CameraStyle.ThirdPerson) {
            
            Vector3 lookAtDirection = lookAtObj.position - new Vector3(transform.position.x, lookAtObj.position.y, transform.position.z);
            orientation.forward = lookAtDirection.normalized;

            playerObj.forward = lookAtDirection.normalized;

        } else if (currentStyle == CameraStyle.FirstPerson) {
            
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");
            Vector3 inputDir = orientation.forward * verticalMovement + orientation.right * horizontalMovement;

            if (inputDir != Vector3.zero)
            {
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
            }        
        }

    }
}
