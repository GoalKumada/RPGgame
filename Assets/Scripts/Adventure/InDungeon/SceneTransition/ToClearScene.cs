using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToClearScene : MonoBehaviour
{
    private bool isOnCollision;
    [SerializeField] WindowMenu windowMenu;
    [SerializeField] GameObject toClearScenePanel;
    [SerializeField] SceneController sceneController;

    void Start()
    {
        
    }

    void Update()
    {
        if (isOnCollision)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (windowMenu.currentID == 0)
                {
                    sceneController.sceneChange("ClearScene");
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                else if (windowMenu.currentID == 1)
                {
                    isOnCollision = false;
                    toClearScenePanel.SetActive(false);
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isOnCollision = false;
                toClearScenePanel.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            toClearScenePanel.SetActive(true);

            windowMenu.SetMoveArrowFunction();

            isOnCollision = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            toClearScenePanel.SetActive(false);

            isOnCollision = false;
        }
    }
}
