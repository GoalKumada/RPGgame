using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoredOrcAttack1 : Skill
{
    public ArmoredOrcAttack1()
    {
        skillName = "こん棒突き";
        attackPower = 40;
        type = Type.attack;
        requiredTP = 5;
        skillExplain = "こん棒で突いて攻撃\r\nＴＰ消費５";
    }
}
