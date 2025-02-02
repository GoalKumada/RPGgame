using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoredAxemanAttack2 : Skill
{
    public ArmoredAxemanAttack2()
    {
        skillName = "血斬斧";
        attackPower = 50;
        type = Type.attack;
        requiredTP = 8;
        skillExplain = "斧を叩きつけて敵をすりつぶす必殺技\r\nＴＰ消費８";
    }
}
