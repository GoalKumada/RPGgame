using Cainos.PixelArtPlatformer_VillageProps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    private bool isOnCollision;
    public bool isOpened;
    private bool isConfirmed;

    [SerializeField] WindowMenu windowMenu;
    [SerializeField] GameObject openChestPanel;
    [SerializeField] GameObject moneyGetPanel;
    [SerializeField] public Chest chest;

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
                    chest.Open();
                    SystemManager.money += 2000; // 2000で固定しておく
                    DungeonProgressManager.isChestOpened[DungeonProgressManager.openedChestNum] = true;
                    DungeonProgressManager.openedChestNum++;
                    isOpened = true;
                    isOnCollision = false;
                    
                    openChestPanel.SetActive(false);
                    moneyGetPanel.SetActive(true);
                }
                else if (windowMenu.currentID == 1)
                {
                    isOnCollision = false;
                    openChestPanel.SetActive(false);
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isOnCollision = false;
                openChestPanel.SetActive(false);
            }
        }

        if (isOpened)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                moneyGetPanel.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isOpened)
        {
            openChestPanel.SetActive(true);

            windowMenu.SetMoveArrowFunction();

            isOnCollision = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            openChestPanel.SetActive(false);

            isOnCollision = false;
        }
    }
}
