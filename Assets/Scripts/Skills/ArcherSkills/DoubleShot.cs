using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShot : Skill
{
    public DoubleShot()
    {
        skillName = "連続矢";
        attackPower = 20;
        type = Type.attack;
        requiredTP = 3;
        skillExplain = "続けざまに弓を放ち相手を攻撃する\r\nＴＰ消費３";
    }
}
