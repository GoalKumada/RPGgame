using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerAttack1 : Skill
{
    public LancerAttack1()
    {
        skillName = "紫電突き";
        attackPower = 50;
        type = Type.attack;
        requiredTP = 8;
        skillExplain = "まばゆい光をまとい前方を槍で突く攻撃\r\nＴＰ消費８";
    }
}
