using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttack1 : Skill
{
    public SoldierAttack1()
    {
        skillName = "叩き斬り";
        attackPower = 30;
        type = Type.attack;
        requiredTP = 4;
        skillExplain = "頭上から剣を振り下ろす攻撃\r\nＴＰ消費４";
    }
}