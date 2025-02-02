using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseSlash : Skill
{
    public　ReverseSlash()
    {
        skillName = "振り上げ斬り";
        attackPower = 30;
        type = Type.attack;
        requiredTP = 4;
        skillExplain = "鋭利な剣を振り上げる攻撃\r\nＴＰ消費４";
    }
}
