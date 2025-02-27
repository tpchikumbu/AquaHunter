using UnityEngine;
using Cinemachine;

public class BuoyDeployment : MonoBehaviour, IInteractable
{
    public CinemachineFreeLook deployCamera;
    public GameObject buoyPrefab;
    public GameObject buoy;
    public Transform spawnPoint;
    public bool toggleDeploy = false;
    public bool toggleInteract = false;
    private GameObject deployVehicle;

    void Start() {
        deployVehicle = GameObject.FindWithTag("Vehicle");
    }

    void Update()
    {   if (deployVehicle == null) {
            deployVehicle = GameObject.FindWithTag("Vehicle");
        }
        if (toggleDeploy) {
            if (buoy == null) {
                buoy = Instantiate(buoyPrefab, spawnPoint.position, Quaternion.identity);
                buoy.SetActive(true);
                Debug.Log("Buoy deployed");
            } else if (toggleInteract){
                Interact();
                toggleInteract = false;
            }
            if (buoy != null && Input.GetKeyDown(KeyCode.Space)) {
                deployCamera.Priority = 10;
                buoy.GetComponent<HDRPHultiFloater>().adjustable = false;
                deployVehicle.SetActive(true);
                Debug.Log("Height adjusting disabled");
                toggleDeploy = false;
            }
        }
        
    }

    public void Interact()
    {
        // Adjusting camera and buoy depth
        toggleDeploy = true;
        Debug.Log("Adjusting camera to buoy");
        deployCamera.Follow = buoy.transform;
        deployCamera.LookAt = buoy.transform;
        deployCamera.Priority = 40;

        Debug.Log("Adjust depth with arrow keys. Exit with spacebar");
        buoy.GetComponent<HDRPHultiFloater>().adjustable = true;
        deployVehicle.SetActive(false);
        Debug.Log("Height adjusting enabled");
    }
    public void Prompt()
    {
        Debug.Log("Press E to deploy buoy.");
    }
}