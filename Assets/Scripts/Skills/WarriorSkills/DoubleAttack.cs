using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleAttack : Skill
{
    public DoubleAttack()
    {
        skillName = "ダブルアタック";
        attackPower = 20;
        requiredTP = 2;
        type = Type.attack;
        skillExplain = "a";

    }
}
