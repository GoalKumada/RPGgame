using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcSlash : Skill
{
    public OrcSlash()
    {
        skillName = "アックスラッシュ";
        attackPower = 30;
        type = Type.attack;
        requiredTP = 3;
        skillExplain = "鈍重な斧で叩き切る技\r\nＴＰ消費３";
    }
}
