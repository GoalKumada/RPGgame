using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepSlam : Skill
{
    public SweepSlam()
    {
        skillName = "薙ぎ叩き";
        attackPower = 30;
        type = Type.attack;
        requiredTP = 5;
        skillExplain = "槍で敵を地面にたたきつける大技\r\nＴＰ消費５";
    }
}