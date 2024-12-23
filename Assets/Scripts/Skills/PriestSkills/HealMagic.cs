using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealMagic : Skill
{
    public HealMagic()
    {
        skillName = "回復魔法";
        attackPower = 10;
        type = Type.heal;
        requiredTP = 3;
        skillExplain = "味方ひとりのＨＰを回復する魔法\r\nＴＰ消費３";
    }
}
