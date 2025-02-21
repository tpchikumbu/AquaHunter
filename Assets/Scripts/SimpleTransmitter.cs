using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTransmitter : MonoBehaviour
{
    public bool isTransmitting = true;
    public float transmissionRange = 100f;
    public float transmissionRate = 180f;
    public LayerMask layersToHit;
    public RaycastHit[] hits = new RaycastHit[5];
    public Vector3 raySize;

    // Start is called before the first frame update
    void Start()
    {   
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (isTransmitting) {
            this.transform.Rotate(Vector3.up, Time.deltaTime * transmissionRate);
            // Emit a raycast from the transmitter to the target
            Debug.DrawRay(this.transform.position, this.transform.forward * transmissionRange);
                        
            // if (Physics.BoxCast(this.transform.position, raySize, this.transform.forward, out RaycastHit hit, this.transform.rotation, transmissionRange, layersToHit)) {
            //     Debug.Log("Hit: " + hit.collider.gameObject.name);
            // }

            // Active echo-locate

            if (Physics.BoxCastNonAlloc(this.transform.position, raySize, this.transform.forward, hits, this.transform.rotation, transmissionRange, layersToHit) > 0) {
                foreach (RaycastHit hit in hits) {
                    if (hit.collider != null) {
                        GameObject hitObject = hit.collider.gameObject;
                        Debug.Log("Ray from "+ this.gameObject.name + " hit: " + hitObject.name + ". Distance: " + hit.distance);
                        if (hitObject.layer == 2) {
                            hitObject.GetComponent<MeshRenderer>().enabled = true;
                        }
                    }
                    
                }
            }
        
        }
    }
}
