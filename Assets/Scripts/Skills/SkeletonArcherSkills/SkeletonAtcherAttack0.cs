using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAtcherAttack0 : Skill
{
    public SkeletonAtcherAttack0()
    {
        skillName = "骨の矢";
        attackPower = 30;
        type = Type.attack;
        requiredTP = 5;
        skillExplain = "自らの骨で作った矢で攻撃\r\nＴＰ消費５";
    }
}
