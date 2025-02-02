using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteOrcAttack2 : Skill
{
    public EliteOrcAttack2()
    {
        skillName = "飛び込み斧";
        attackPower = 70;
        type = Type.attack;
        requiredTP = 16;
        skillExplain = "敵にとびかかり襲い掛かる必殺技\r\nＴＰ消費１6";
    }
}
