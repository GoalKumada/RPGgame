using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public string skillName;
    public int attackPower;
    protected enum Type {attack,heal,buff,debuff};
    protected Type type;
    public string skillExplain;


}