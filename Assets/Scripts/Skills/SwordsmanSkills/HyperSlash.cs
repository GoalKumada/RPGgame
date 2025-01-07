using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperSlash : Skill
{
    public HyperSlash()
    {
        skillName = "羅刹斬";
        attackPower = 30;
        requiredTP = 5;
        type = Type.attack;
        skillExplain = "一瞬のうちに敵を切り伏せる究極の技\r\n消費ＴＰ５";

    }
}