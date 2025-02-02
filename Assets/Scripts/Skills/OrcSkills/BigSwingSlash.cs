using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSwingSlash : Skill
{
    public BigSwingSlash()
    {
        skillName = "叩き落とし斬り";
        attackPower = 40;
        type = Type.attack;
        requiredTP = 5;
        skillExplain = "力を込めて相手に斧を振り下ろす必殺技\r\nＴＰ消費５";
    }
}
