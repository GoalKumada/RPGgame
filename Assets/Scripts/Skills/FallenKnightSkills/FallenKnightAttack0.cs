using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenKnightAttack0 : Skill
{
    public FallenKnightAttack0()
    {
        skillName = "叩き斬り";
        attackPower = 30;
        type = Type.attack;
        requiredTP = 3;
        skillExplain = "上から剣で切りつける攻撃\r\nＴＰ消費３";
    }
}
