using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearSlash : Skill
{
    public BearSlash()
    {
        skillName = "鋭利な爪";
        attackPower = 20;
        type = Type.attack;
        requiredTP = 3;
        skillExplain = "鋭い爪で切りかかる攻撃\r\nＴＰ消費３";
    }
}
