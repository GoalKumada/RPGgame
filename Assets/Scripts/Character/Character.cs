using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] public string characterName;
    [SerializeField] public float HP;
    [SerializeField] public float TP;
    [SerializeField] private float DEF;

    [SerializeField] public Skill[] skills;

    public string[] GetStringsOfSkills()
    {
        List<string> list = new List<string>();
        foreach (Skill skill in skills)
        {
            list.Add(skill.skillName);
        }

        return list.ToArray();
    }

    public void Attack(Character target, int skillNumber)
    {
        int damage = 5;
        target.HP -= damage;
        Debug.Log($"{characterName}の攻撃！ {target.characterName}に{damage}のダメージ");
        if (target.HP > 0)
        {
            Debug.Log($"{target.characterName}の残りHPは{target.HP}。");
        }
        else
        {
            Debug.Log($"{target.characterName}を倒した！");
        }
    }

    public void UseSkill(Character target, int skillNumber)
    {
        target.HP -= skills[skillNumber].attackPower;
        Debug.Log($"{characterName}の{skills[skillNumber].skillName}! {target.characterName}に{skills[skillNumber].attackPower}のダメージ");
        if (target.HP > 0)
        {
            Debug.Log($"{target.characterName}の残りHPは{target.HP}。");
        }
        else
        {
            Debug.Log($"{target.characterName}を倒した！");
        }
    }
}
