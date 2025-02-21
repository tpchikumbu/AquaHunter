using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject MenuUI;
    public GameObject HUD;
    // Start is called before the first frame update
    void Start()
    {
        Pause();
        Cursor.visible = true;
    }
    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MenuUI.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }        
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        MenuUI.SetActive(false);
        HUD.SetActive(true);
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        MenuUI.SetActive(true);
        HUD.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
