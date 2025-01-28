using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAttack : Skill
{
    public SlashAttack()
    {
        skillName = "切り払い";
        attackPower = 20;
        type = Type.attack;
        requiredTP = 3;
        skillExplain = "刃物を形成し前方の敵を切り払う攻撃\r\nＴＰ消費３";
    }
}
