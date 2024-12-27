using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public string skillName;
    public int attackPower;
    public int requiredTP;
    public enum Type {attack,heal,buff,debuff};
    public Type type;
    public string skillExplain;


}
