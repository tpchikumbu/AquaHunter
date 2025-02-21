using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceBuoyDeployment : MonoBehaviour
{
    public GameObject deployable;
    public Transform spawnPoint;
    public int deployableCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (deployable != null) {
            // Debug.Log("Deployable exists");
            if (Input.GetKeyDown(KeyCode.B) && deployableCount > 0) {
                Instantiate(deployable, spawnPoint.position, Quaternion.identity).SetActive(true);
                --deployableCount;
                Debug.Log("Buoy deployed");
            }
        }
        
        
    }
}
