using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarTransmitter : MonoBehaviour
{
    public bool isTransmitting = false;
    private bool hasCleared = false;
    
    public float transmissionRange = 100f;
    public float transmissionRate = 180f;
    public GameObject transmitter;
    public LayerMask layersToHit;
    // public RaycastHit[] hits = new RaycastHit[5];
    public RaycastHit hit;
    private List<Collider> hitColliders;
    [SerializeField] private Transform pingPrefab;

    // public Ray ray;
    public Vector3 raySize;
    // Start is called before the first frame update
    void Start()
    {
        hitColliders = new List<Collider>();
        // ray = new Ray(transmitter.transform.position, transmitter.transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (isTransmitting) {
            transmitter.transform.Rotate(Vector3.up, Time.deltaTime * transmissionRate);
            // Emit a raycast from the transmitter to the target
            Debug.DrawRay(transmitter.transform.position, transmitter.transform.forward * transmissionRange);

            if (transmitter.transform.rotation.eulerAngles.y >= 180f && !hasCleared) {
                hitColliders.Clear();
                hasCleared = true;
            } else if (transmitter.transform.rotation.eulerAngles.y < 180f) {
                hasCleared = false;
            }

            if (Physics.BoxCast(transmitter.transform.position, raySize, transmitter.transform.forward, out hit, transmitter.transform.rotation, transmissionRange, layersToHit)) {
                if (!hitColliders.Contains(hit.collider)) {
                    Debug.Log("Box Hit: " + hit.collider.gameObject.name);
                    hitColliders.Add(hit.collider);
                    Instantiate(pingPrefab, new Vector3(hit.point.x, 30, hit.point.z), Quaternion.Euler(90, 0, 0));
                }
            }
            // if (Physics.Raycast(transmitter.transform.position, transmitter.transform.forward, out hit, transmissionRange, layersToHit)) {
            //     Debug.Log("Ray Hit: " + hit.collider.gameObject.name);
            // }

            // Active echo-locate

            // if (Physics.BoxCastNonAlloc(transmitter.transform.position, raySize, transmitter.transform.forward, hits, transmitter.transform.rotation, transmissionRange, layersToHit) > 0) {
            //     foreach (RaycastHit hit in hits) {
            //         if (hit.collider != null) {
            //             Debug.Log("Ray from "+ this.gameObject.name + " hit: " + hit.collider.gameObject.name);
            //         }
            //     }
            // }
        }
    }
}
