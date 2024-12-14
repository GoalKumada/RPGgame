using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardStab : Skill
{
    public ForwardStab()
    {
        skillName = "前突き";
        attackPower = 10;
        requiredTP = 0;
        type = Type.attack;
        skillExplain = "前方の敵を突き刺す\r\n消費ＴＰ０";

    }
}
