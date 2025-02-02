using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromTownToDungeon : MonoBehaviour
{
    private bool isPaused;
    private bool isCautioned;
    [SerializeField] public GameObject toDungeonPanel;
    [SerializeField] public GameObject cautionPanel;
    [SerializeField] public WindowMenu windowMenu;
    private Vector3 EntranceToTheCity = new Vector3(0, 0.2f, -6.0f);

    private void Start()
    {

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
            else if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Resume();
                isPaused = false;
                toDungeonPanel.SetActive(false);
            }
        }

        if (isCautioned)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftShift))
            {
                cautionPanel.SetActive(false);
                Resume();
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (SystemManager.allyComponents.Count != 0)
            {
                toDungeonPanel.SetActive(true);

                windowMenu.SetMoveArrowFunction();

                Pause();

                isPaused = true;
            }
            else
            {
                cautionPanel.SetActive(true);

                Pause();

                isCautioned = true;
            }
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
