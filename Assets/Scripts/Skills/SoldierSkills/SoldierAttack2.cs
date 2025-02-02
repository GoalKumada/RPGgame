using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttack2 : Skill
{
    public SoldierAttack2()
    {
        skillName = "隠し矢";
        attackPower = 30;
        type = Type.attack;
        requiredTP = 5;
        skillExplain = "隠し持った弓で素早く敵を射抜く攻撃\r\nＴＰ消費５";
    }
}