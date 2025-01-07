using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slash : Skill
{
    public Slash()
    {
        skillName = "切り上げ";
        attackPower = 10;
        type = Type.attack;
        requiredTP = 0;
        skillExplain = "剣を振り上げ敵を切りつける技\r\nＴＰ消費０";
    }
}
