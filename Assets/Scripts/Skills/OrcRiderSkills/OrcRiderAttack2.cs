using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcRiderAttack2 : Skill
{
    public OrcRiderAttack2()
    {
        skillName = "大暴れ";
        attackPower = 80;
        type = Type.attack;
        requiredTP = 20;
        skillExplain = "無心でただ大暴れする危険な技\r\nＴＰ消費２０";
    }
}
