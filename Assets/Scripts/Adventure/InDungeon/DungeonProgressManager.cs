using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonProgressManager : MonoBehaviour
{
    public static bool[] isBattleCompleted = new bool[9];

    public static int numOfBattlesAttempting = 0;

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
    }

    void Update()
    {
        
    }
}
