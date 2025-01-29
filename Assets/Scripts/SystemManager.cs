using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager
{
    public static int money = 6000;

    public static List<string> employedAllyNames = new List<string>();

    public static List<Ally> allyComponents = new List<Ally>();
    public static List<Sprite> sprites = new List<Sprite>();
    public static List<Color> colorsOfSpriteProperty = new List<Color>();
    public static List<RuntimeAnimatorController> runtimeAnimatorControllers = new List<RuntimeAnimatorController>();
    public static List<Skill[]> skills = new List<Skill[]>();

}