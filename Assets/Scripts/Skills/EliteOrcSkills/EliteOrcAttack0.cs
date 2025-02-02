using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteOrcAttack0 : Skill
{
    public EliteOrcAttack0()
    {
        skillName = "切り裂き";
        attackPower = 40;
        type = Type.attack;
        requiredTP = 5;
        skillExplain = "強大な斧で切りつける攻撃\r\nＴＰ消費５";
    }
}
