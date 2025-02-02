using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoredAxemanAttack1 : Skill
{
    public ArmoredAxemanAttack1()
    {
        skillName = "回転切り";
        attackPower = 40;
        type = Type.attack;
        requiredTP = 5;
        skillExplain = "回転しながら斧で切りつける攻撃\r\nＴＰ消費５";
    }
}
