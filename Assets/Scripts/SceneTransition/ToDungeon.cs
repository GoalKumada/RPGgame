using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToDungeon : MonoBehaviour
{
    private bool isPaused = false;
    private WindowMenu wm;
    private GameObject toDungeonPanel;

    private void Start()
    {
        toDungeonPanel = GameObject.Find("UI/TextCanvas/ToDungeonPanel");

        GameObject optionPanel = GameObject.Find("UI/TextCanvas/ToDungeonPanel/OptionsPanel");
        wm = optionPanel.GetComponent<WindowMenu>();
    }

    private void Update()
    {
        if (isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (wm.currentID == 0)
                {
                    SceneManager.LoadScene("DungeonScene");
                }
                else if (wm.currentID == 1)
                {
                    Time.timeScale = 1.0f;
                    isPaused = false;
                    toDungeonPanel.SetActive(false);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1.0f;
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

            wm.SetMoveArrowFunction();

            Time.timeScale = 0;

            isPaused = true;

        }
    }
}
