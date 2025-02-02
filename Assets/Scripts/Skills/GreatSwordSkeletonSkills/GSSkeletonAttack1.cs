using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSSkeletonAttack1 : Skill
{
    public GSSkeletonAttack1()
    {
        skillName = "大地斬り";
        attackPower = 40;
        type = Type.attack;
        requiredTP = 8;
        skillExplain = "重たい剣を思い切り振り下ろす攻撃\r\nＴＰ消費8";
    }
}
