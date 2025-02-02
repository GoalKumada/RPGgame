using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] public GameObject pausePanel;
    public bool isPausable = true;
    public bool isPaused;

    void Start()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (isPausable && !isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                isPaused = true;
                pausePanel.SetActive(true);
            }
        }
        else if (isPausable && isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1.0f;
                isPaused = false;
                pausePanel.SetActive(false);
            }
        }
    }
}
