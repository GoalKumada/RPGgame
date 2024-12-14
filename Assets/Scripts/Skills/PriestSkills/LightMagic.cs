using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMagic : Skill
{
    public LightMagic()
    {
        skillName = "狙い撃ち";
        attackPower = 10;
        type = Type.attack;
        requiredTP = 0;
        skillExplain = "敵一体を弓矢で狙い撃つ\r\nＴＰ消費０";
    }
}
