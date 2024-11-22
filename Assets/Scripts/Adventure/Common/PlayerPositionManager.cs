using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPositionManager : MonoBehaviour
{
    public static Vector3 posOfPlayerInTown = new Vector3(0, 0.2f, -6.0f);
    public static Vector3 posOfPlayerInDungeon = new Vector3(-5.0f, 0.15f, -3.0f);

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "TownScene")
        {
            if (posOfPlayerInTown != Vector3.zero)
            {
                transform.position = posOfPlayerInTown;
            }
        }
        else if (SceneManager.GetActiveScene().name == "DungeonScene")
        {
            if (posOfPlayerInDungeon != Vector3.zero)
            {
                transform.position = posOfPlayerInDungeon;
            }
            else
            {
                Debug.Log("位置がゼロ");
            }
        }
    }
}
