using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromTownToDungeon : MonoBehaviour
{
    private bool isPaused = false;
    private WindowMenu windowMenu;
    private GameObject toDungeonPanel;
    private Vector3 EntranceToTheCity = new Vector3(0, 0.2f, -6.0f);

    private void Start()
    {
        toDungeonPanel = GameObject.Find("UI/TextCanvas/ToDungeonPanel");

        GameObject optionPanel = GameObject.Find("UI/TextCanvas/ToDungeonPanel/OptionsPanel");
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
                    PlayerPositionManager.posOfPlayerInTown = EntranceToTheCity;

                    Resume();

                    GameObject sceneController = GameObject.Find("SceneController");
                    sceneController.GetComponent<SceneController>().sceneChange("DungeonScene");
                }
                else if (windowMenu.currentID == 1)
                {
                    Resume();
                    isPaused = false;
                    toDungeonPanel.SetActive(false);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Resume();
                isPaused = false;
                toDungeonPanel.SetActive(false);
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("衝突判定されている");

            toDungeonPanel.SetActive(true);

            windowMenu.SetMoveArrowFunction();

            Pause();

            isPaused = true;

        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
    }
}
