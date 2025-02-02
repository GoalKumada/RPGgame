using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSSkeletonAttack0 : Skill
{
    public GSSkeletonAttack0()
    {
        skillName = "切り上げ";
        attackPower = 40;
        type = Type.attack;
        requiredTP = 3;
        skillExplain = "重たい剣を振り上げて攻撃\r\nＴＰ消費３";
    }
}
