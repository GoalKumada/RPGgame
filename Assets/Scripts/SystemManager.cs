using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    [SerializeField] public static int money = 1500;

    public static List<GameObject> currentPartyMember = new List<GameObject>();

    public static int number = 1;
}
