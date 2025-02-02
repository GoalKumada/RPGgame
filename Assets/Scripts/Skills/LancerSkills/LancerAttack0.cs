using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerAttack0 : Skill
{
    public LancerAttack0()
    {
        skillName = "前突き";
        attackPower = 30;
        type = Type.attack;
        requiredTP = 5;
        skillExplain = "前方を槍で突く攻撃\r\nＴＰ消費５";
    }
}
