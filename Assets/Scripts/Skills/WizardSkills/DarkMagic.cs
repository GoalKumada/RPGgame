using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMagic : Skill
{
    public DarkMagic()
    {
        skillName = "闇の魔法";
        attackPower = 30;
        type = Type.attack;
        requiredTP = 5;
        skillExplain = "禁断の闇の魔法で敵を攻撃する\r\nＴＰ消費５";
    }
}
