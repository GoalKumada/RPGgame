using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoredOrcAttack0 : Skill
{
    public ArmoredOrcAttack0()
    {
        skillName = "こん棒叩き";
        attackPower = 40;
        type = Type.attack;
        requiredTP = 5;
        skillExplain = "こん棒で叩きつけて攻撃\r\nＴＰ消費５";
    }
}
