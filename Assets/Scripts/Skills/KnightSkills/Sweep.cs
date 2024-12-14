using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweep : Skill
{
    public Sweep()
    {
        skillName = "薙ぎ払い";
        attackPower = 20;
        requiredTP = 2;
        type = Type.attack;
        skillExplain = "槍で前方を大きく振り払う\r\n消費ＴＰ２";

    }
}
