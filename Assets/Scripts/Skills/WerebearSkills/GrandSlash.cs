using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandSlash : Skill
{
    public GrandSlash()
    {
        skillName = "大地裂き";
        attackPower = 40;
        type = Type.attack;
        requiredTP = 5;
        skillExplain = "大地を切り裂く強烈な必殺技\r\nＴＰ消費５";
    }
}
