using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class HDRPInvertedFloater : MonoBehaviour
{
    public WaterSurface waterSurface;
    public Transform[] floatPoints;
    public Rigidbody rb;

    public float waterDrag = 10f;
    public float waterAngularDrag = 0.5f;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;
    public int floaterCount = 1;

    WaterSearchParameters searchParameters = new WaterSearchParameters();
    WaterSearchResult searchResult = new WaterSearchResult();
    
    void Awake() {
        waterSurface = FindObjectOfType<WaterSurface>();
        rb = GetComponentInParent<Rigidbody>();
        rb.useGravity = false;
    }

    void FixedUpdate() {
        rb.AddForceAtPosition(Physics.gravity / floaterCount, transform.position, ForceMode.Acceleration);
        searchParameters.startPosition = transform.position;
        waterSurface.FindWaterSurfaceHeight(searchParameters, out searchResult);

        if (transform.position.y < searchResult.height) {
            float displacementMultiplier = Mathf.Clamp01((searchResult.height - transform.position.y) / depthBeforeSubmerged) * displacementAmount;
            // rb.AddForceAtPosition(Physics.gravity * displacementMultiplier, transform.position, ForceMode.Acceleration);
            // rb.AddForce(rb.velocity * -1 * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            // rb.AddTorque(rb.angularVelocity * -1 * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            
            rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), transform.position, ForceMode.Acceleration);
            rb.AddForce(displacementMultiplier * -rb.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rb.AddTorque(displacementMultiplier * -rb.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}
