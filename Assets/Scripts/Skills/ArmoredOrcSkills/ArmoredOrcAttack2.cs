using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoredOrcAttack2 : Skill
{
    public ArmoredOrcAttack2()
    {
        skillName = "大地割き";
        attackPower = 60;
        type = Type.attack;
        requiredTP = 15;
        skillExplain = "地面を割くほどの衝撃を生む必殺技\r\nＴＰ消費１５";
    }
}
