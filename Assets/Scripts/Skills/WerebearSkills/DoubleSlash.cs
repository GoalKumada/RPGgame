using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSlash : Skill
{
    public DoubleSlash()
    {
        skillName = "二連切り裂き";
        attackPower = 30;
        type = Type.attack;
        requiredTP = 4;
        skillExplain = "鋭い爪で連続で切りかかる大技\r\nＴＰ消費４";
    }
}
