using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

interface IInteractable
{

    public void Interact();
    public void Prompt();
}

public class Interactor : MonoBehaviour
{
    public float interactDistance = 5f;
    public float rayOffset = 1f;
    public LayerMask interactLayer;
    public Vector3 raycastPosition;

    void Start()
    {
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        // Gizmos.DrawSphere(raycastPosition, interactDistance);
        Gizmos.DrawSphere(raycastPosition, interactDistance);  
    }

    // Update is called once per frame
    void Update()
    {
        raycastPosition = transform.position + new Vector3(0, rayOffset, 0);
        RaycastHit hit;
        Debug.DrawRay(raycastPosition, transform.forward * interactDistance, Color.red);
        if (Physics.SphereCast(raycastPosition, interactDistance, transform.forward, out hit, interactDistance, interactLayer)){
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            Debug.Log(hit.collider.name);
            if (interactable != null) {
                interactable.Prompt();
                if (Input.GetKeyDown(KeyCode.E)) {
                    interactable.Interact();
                }
            }
        }  
    }
}
