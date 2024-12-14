using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMagic : Skill
{
    public IceMagic()
    {
        skillName = "氷の魔法";
        attackPower = 20;
        type = Type.attack;
        requiredTP = 3;
        skillExplain = "氷のつぶてを放ち敵を凍えさせる\r\nＴＰ消費３";
    }
}
