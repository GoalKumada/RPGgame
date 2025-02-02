using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenKnightAttack1 : Skill
{
    public FallenKnightAttack1()
    {
        skillName = "上下段斬り";
        attackPower = 40;
        type = Type.attack;
        requiredTP = 5;
        skillExplain = "敵を上下に切りつける攻撃\r\nＴＰ消費５";
    }
}
