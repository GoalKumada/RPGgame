using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToBattle : MonoBehaviour
{
    public static bool isSelecting = false;
    private bool isCollided = false;
    private WindowMenu windowMenu;
    private GameObject toBattlePanel;
    private Vector3 currentPos = new Vector3(0 ,0, 0);
    private float distance = 0.5f; //位置調整用

    private void Start()
    {
        toBattlePanel = GameObject.Find("UI/TextCanvas/ToBattlePanel");

        GameObject optionPanel = GameObject.Find("UI/TextCanvas/ToBattlePanel/OptionsPanel");
        windowMenu = optionPanel.GetComponent<WindowMenu>();
    }

    private void Update()
    {
        if (isSelecting && isCollided)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (windowMenu.currentID == 0)
                {
                    PlayerPositionManager.posOfPlayerInDungeon = currentPos;

                    GameObject sceneController = GameObject.Find("SceneController");
                    sceneController.GetComponent<SceneController>().sceneChange($"BattleScene_{DungeonProgressManager.attemptingBattleNum}");

                    toBattlePanel.SetActive(false);
                    isCollided = false;
                    isSelecting = false;
                }
                else if (windowMenu.currentID == 1)
                {
                    toBattlePanel.SetActive(false);
                    isCollided = false;
                    isSelecting = false;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                toBattlePanel.SetActive(false);
                isCollided = false;
                isSelecting = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            currentPos = collision.gameObject.transform.position;
            currentPos.x -= distance;
            
            toBattlePanel.SetActive(true);
            windowMenu.SetMoveArrowFunction();
            
            isCollided = true;
            isSelecting = true;
        }
    }
}
