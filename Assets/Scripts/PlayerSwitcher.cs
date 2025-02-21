using UnityEngine;
using Cinemachine;

public class PlayerSwitcher : MonoBehaviour
{
    public CinemachineFreeLook[] cameras;
    public GameObject[] players;
    public int currentIndex = 0;
    public int lastIndex = 0;
    [SerializeField] private GameObject mapCamera;

    private void Start()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == currentIndex)
            {
                cameras[i].Priority = 20;
            }
            else
            {
                cameras[i].Priority = 10;
            }
        }
        mapCamera.GetComponent<LimitCamera>().followObject = players[currentIndex];
    }

    private void Update() {
        SwitchIndex();
        if (currentIndex != lastIndex)
        {
            SwitchCamera();
            SwitchPlayer();
            lastIndex = currentIndex;
        }
    }

    public void SwitchIndex()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = players.Length - 1;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            currentIndex++;
            if (currentIndex >= players.Length)
            {
                currentIndex = 0;
            }
        }
    }

    public void SwitchCamera()
    {
        
        cameras[currentIndex].Priority = 20;

        for (int i = 0; i < cameras.Length; i++)
        {
            if (i != currentIndex)
            {
                cameras[i].Priority = 10;
            }
        }
    }
    public void SwitchPlayer()
    {
        players[currentIndex].SetActive(true);

        for (int i = 0; i < players.Length; i++)
        {
            if (i != currentIndex)
            {
                players[i].SetActive(false);
            }
        }
        mapCamera.GetComponent<LimitCamera>().followObject = players[currentIndex];
    }
}