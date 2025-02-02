using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerAttack2 : Skill
{
    public LancerAttack2()
    {
        skillName = "超絶突進";
        attackPower = 60;
        type = Type.attack;
        requiredTP = 15;
        skillExplain = "捨て身で突き進み続ける必殺技\r\nＴＰ消費１５";
    }
}
