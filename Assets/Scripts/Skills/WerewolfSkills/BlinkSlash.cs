using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkSlash : Skill
{
    public BlinkSlash()
    {
        skillName = "見切り斬り";
        attackPower = 30;
        type = Type.attack;
        requiredTP = 5;
        skillExplain = "一瞬で敵の懐に飛び込み切りかかる必殺技\r\nＴＰ消費５";
    }
}
