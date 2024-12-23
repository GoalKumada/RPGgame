using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamAttack : Skill
{
    public SlamAttack()
    {
        skillName = "叩きつけ";
        attackPower = 10;
        type = Type.attack;
        requiredTP = 0;
        skillExplain = "手持ちの杖で敵をたたきつける\r\nＴＰ消費０";
    }
}
