using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoredAxemanAttack0 : Skill
{
    public ArmoredAxemanAttack0()
    {
        skillName = "斧振り下ろし";
        attackPower = 30;
        type = Type.attack;
        requiredTP = 3;
        skillExplain = "斧を振り下ろし切りかかる攻撃\r\nＴＰ消費３";
    }
}
