using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabAttack : Skill
{
    public StabAttack()
    {
        skillName = "突き刺し";
        attackPower = 10;
        type = Type.attack;
        requiredTP = 2;
        skillExplain = "刃物を形成し前方の敵を突き刺す攻撃\r\nＴＰ消費２";
    }
}
