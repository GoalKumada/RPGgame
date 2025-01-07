using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousThrust : Skill
{
    public ContinuousThrust()
    {
        skillName = "連続突き";
        attackPower = 20;
        requiredTP = 2;
        type = Type.attack;
        skillExplain = "敵を素早く連続で切るつける\r\n消費ＴＰ２";

    }
}
