using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAttack : Skill
{
    public ShieldAttack()
    {
        skillName = "シールドアタック";
        attackPower = 30;
        type = Type.attack;
        requiredTP = 5;
        skillExplain = "盾で敵を地面にたたきつける大技\r\nＴＰ消費５";
    }
}
