using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FromDungeonToTown : MonoBehaviour
{
    private bool isPaused = false;
    private WindowMenu windowMenu;
    private GameObject toTownPanel;

    private void Start()
    {
        toTownPanel = GameObject.Find("UI/TextCanvas/ToTownPanel");

        GameObject optionPanel = GameObject.Find("UI/TextCanvas/ToTownPanel/OptionsPanel");
        windowMenu = optionPanel.GetComponent<WindowMenu>();
    }

    private void Update()
    {
        if (isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (windowMenu.currentID == 0)
                {
                    Time.timeScale = 1.0f;

                    GameObject sceneController = GameObject.Find("SceneController");
                    sceneController.GetComponent<SceneController>().sceneChange("TownScene");
                }
                else if (windowMenu.currentID == 1)
                {
                    Time.timeScale = 1.0f;
                    isPaused = false;
                    toTownPanel.SetActive(false);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1.0f;
                isPaused = false;
                toTownPanel.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            toTownPanel.SetActive(true);

            windowMenu.SetMoveArrowFunction();

            Time.timeScale = 0;

            isPaused = true;
        }
    }
}
