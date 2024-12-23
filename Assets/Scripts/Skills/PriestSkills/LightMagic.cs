using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMagic : Skill
{
    public LightMagic()
    {
        skillName = "光の魔法";
        attackPower = 30;
        type = Type.attack;
        requiredTP = 5;
        skillExplain = "聖なる光の魔法で敵を攻撃する\r\nＴＰ消費５";
    }
}
