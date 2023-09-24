using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject menuPause;
    private bool isPause = false;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!isPause)
            {
                isPause = true;
                menuPause.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                isPause = false;
                menuPause.SetActive(false);
                Time.timeScale = 1f;
            }
        }
        
    }
}
