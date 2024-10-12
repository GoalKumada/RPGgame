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
        skillExplain = "回転しながら強く敵を切り伏せる必殺技\r\n消費TP５";

    }
}
