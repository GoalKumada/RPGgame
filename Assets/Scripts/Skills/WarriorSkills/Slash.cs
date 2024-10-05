using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slash : Skill
{
    public Slash()
    {
        skillName = "スラッシュ";
        attackPower = 10;
        type = Type.attack;
        requiredTP = 0;
        skillExplain = "あ";
    }
}
