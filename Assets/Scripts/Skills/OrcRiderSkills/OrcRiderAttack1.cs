using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcRiderAttack1 : Skill
{
    public OrcRiderAttack1()
    {
        skillName = "叩きつけ";
        attackPower = 60;
        type = Type.attack;
        requiredTP = 12;
        skillExplain = "必殺のフレイルで叩きつける攻撃\r\nＴＰ消費１２";
    }
}
