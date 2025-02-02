using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSlash : Skill
{
    public WolfSlash()
    {
        skillName = "切りつけ";
        attackPower = 20;
        type = Type.attack;
        requiredTP = 3;
        skillExplain = "牙ではなく剣で切りかかる攻撃\r\nＴＰ消費３";
    }
}
