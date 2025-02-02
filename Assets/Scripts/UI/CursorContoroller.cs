using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorContoroller : MonoBehaviour
{
    [SerializeField] private PauseController pauseController;
    private bool isCorsorLocked;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isCorsorLocked = true;
    }

    void Update()
    {

        if (isCorsorLocked && pauseController.isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isCorsorLocked = false;
        }

        if (!isCorsorLocked && !pauseController.isPaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isCorsorLocked = true;
        }
    }
}