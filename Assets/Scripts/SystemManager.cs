using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager
{
    public static int money = 1500;

    //public static List<GameObject> currentPartyMember = new List<GameObject>();
    public static List<Ally> allyComponentsOfCurrentPartyMember = new List<Ally>();
    public static List<Sprite> spritesOfCurrentPartyMember = new List<Sprite>();
    public static List<RuntimeAnimatorController> controllersOfCurrentPartyMember = new List<RuntimeAnimatorController>();
    public static List<Skill[]> skillsOfCurrentPartyMember = new List<Skill[]>();

}

