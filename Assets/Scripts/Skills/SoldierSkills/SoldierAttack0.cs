using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttack0 : Skill
{
    public SoldierAttack0()
    {
        skillName = "スラッシュ";
        attackPower = 25;
        type = Type.attack;
        requiredTP = 3;
        skillExplain = "鋭利な剣で切りかかる攻撃\r\nＴＰ消費３";
    }
}