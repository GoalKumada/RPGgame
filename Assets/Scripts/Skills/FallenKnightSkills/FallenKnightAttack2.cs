using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenKnightAttack2 : Skill
{
    public FallenKnightAttack2()
    {
        skillName = "火炎斬";
        attackPower = 50;
        type = Type.attack;
        requiredTP = 7;
        skillExplain = "炎をまとった剣で叩き切る必殺技\r\nＴＰ消費７";
    }
}
