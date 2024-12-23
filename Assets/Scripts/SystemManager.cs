using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    [SerializeField] public static int money = 1000;

    public static List<GameObject> currentPartyMember = new List<GameObject>();

    private void Start()
    {
        foreach (GameObject go in currentPartyMember)
        {
            Debug.Log(go.GetComponent<Ally>().characterName);
        }
    }
}
