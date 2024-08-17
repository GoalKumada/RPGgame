using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    protected string skillName;
    protected int attackPower;
    protected enum Type {attack,heal,buff,debuff};
    protected Type type;
    protected string skillExplain;


}
