using Cainos.PixelArtPlatformer_VillageProps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonProgressManager : MonoBehaviour
{
    public static bool[] isBattleCompleted = new bool[9];
    public static bool[] isChestOpened = new bool[2];

    public static int attemptingBattleNum = 0;
    public static int openedChestNum = 0;

    [SerializeField] OpenChest[] openChests;

    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            if (isBattleCompleted[i])
            {
                GameObject gameObject = GameObject.Find($"ToBattle_{i}");
                Collider collider = gameObject.GetComponent<BoxCollider>();
                collider.enabled = false;
            }
            else
            {
                break;
            }
        }

        for (int i = 0; i < 2; i++)
        {
            if (isChestOpened[i])
            {
                openChests[i].chest.Open();
                openChests[i].isOpened = true;
            }
            else
            {
                break;
            }
        }
    }
}
