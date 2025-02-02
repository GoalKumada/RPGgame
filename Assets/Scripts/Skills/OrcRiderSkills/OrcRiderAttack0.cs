using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcRiderAttack0 : Skill
{
    public OrcRiderAttack0()
    {
        skillName = "獣の牙";
        attackPower = 50;
        type = Type.attack;
        requiredTP = 10;
        skillExplain = "しもべの獣に命令して牙で割く攻撃\r\nＴＰ消費１０";
    }
}
