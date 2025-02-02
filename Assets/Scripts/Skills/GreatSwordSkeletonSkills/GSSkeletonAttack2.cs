using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSSkeletonAttack2 : Skill
{
    public GSSkeletonAttack2()
    {
        skillName = "貫き斬り";
        attackPower = 40;
        type = Type.attack;
        requiredTP = 5;
        skillExplain = "前方を突く攻撃\r\nＴＰ消費５";
    }
}
