using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    public GameObject controls;
    public GameObject livesbar;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1F;
        GameisPaused = false;
        controls.SetActive(true);
        livesbar.SetActive(true);
    }

    public void Pause()
    {
        controls.SetActive(false);
        livesbar.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0F;
        GameisPaused = true;
    }

}
