using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMagic : Skill
{
    public FireMagic()
    {
        skillName = "炎の魔法";
        attackPower = 20;
        type = Type.attack;
        requiredTP = 3;
        skillExplain = "火の玉を放ち敵を燃やす\r\nＴＰ消費３";
    }
}
