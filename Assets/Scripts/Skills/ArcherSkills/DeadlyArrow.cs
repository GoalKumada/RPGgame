using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyArrow : Skill
{
    public DeadlyArrow()
    {
        skillName = "必殺の一矢";
        attackPower = 30;
        type = Type.attack;
        requiredTP = 5;
        skillExplain = "集中力を高めて敵に必殺の一撃を放つ大技\r\nＴＰ消費５";
    }
}
