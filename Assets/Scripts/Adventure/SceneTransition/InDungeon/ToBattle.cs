using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToBattle : MonoBehaviour
{
    private bool isPaused = false;
    private WindowMenu windowMenu;
    private GameObject toBattlePanel;

    private void Start()
    {
        toBattlePanel = GameObject.Find("UI/TextCanvas/ToBattlePanel");

        GameObject optionPanel = GameObject.Find("UI/TextCanvas/ToBattlePanel/OptionsPanel");
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
                    sceneController.GetComponent<SceneController>().sceneChange("BattleScene");
                }
                else if (windowMenu.currentID == 1)
                {
                    Time.timeScale = 1.0f;
                    isPaused = false;
                    toBattlePanel.SetActive(false);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1.0f;
                isPaused = false;
                toBattlePanel.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            toBattlePanel.SetActive(true);

            windowMenu.SetMoveArrowFunction();

            Time.timeScale = 0;

            isPaused = true;
        }
    }
}
