using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteOrcAttack1 : Skill
{
    public EliteOrcAttack1()
    {
        skillName = "回転斧";
        attackPower = 50;
        type = Type.attack;
        requiredTP = 12;
        skillExplain = "回転して斧で連続で切りかかる攻撃\r\nＴＰ消費１２";
    }
}
