using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slash : Skill
{
    public void Start()
    {
        skillName = "スラッシュ";
        attackPower = 10;
        type = Type.attack;

        skillExplain = "あ";
    }
}
