using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAttack : Skill
{
    public SpinAttack()
    {
        skillName = "回転切り";
        attackPower = 30;
        requiredTP = 5;
        type = Type.attack;
        skillExplain = "a";

    }
}
