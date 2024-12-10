using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] public string characterName;
    [SerializeField] public float currentHP;
    [SerializeField] public float maxHP;
    [SerializeField] public int currentTP;
    [SerializeField] public int maxTP;
    [SerializeField] public float ATK;
    [SerializeField] public float currentATK;
    [SerializeField] public float DEF;
    [SerializeField] public float currentDEF;
    [SerializeField] public Skill[] skills;

    private void Awake()
    {
        currentHP = maxHP;
        currentTP = maxTP;
    }

    public string[] GetStringsOfSkills()
    {
        List<string> list = new List<string>();
        foreach (Skill skill in skills)
        {
            list.Add(skill.skillName);
        }

        return list.ToArray();
    }

    /*
    public void Attack(Character target, int skillNumber)
    {
        int damage = 5;
        target.currentHP -= damage;
        Debug.Log($"{characterName}の攻撃！ {target.characterName}に{damage}のダメージ");
        if (target.currentHP > 0)
        {
            Debug.Log($"{target.characterName}の残りHPは{target.currentHP}。");
        }
        else
        {
            Debug.Log($"{target.characterName}を倒した！");
        }
    }
    */

    public void UseSkill(Character target, int skillNumber)
    {
        target.currentHP -= skills[skillNumber].attackPower;
        currentTP -= skills[skillNumber].requiredTP;
        
        Debug.Log($"{characterName}の{skills[skillNumber].skillName}! {target.characterName}に{skills[skillNumber].attackPower}のダメージ");
        if (target.currentHP > 0)
        {
            Debug.Log($"{target.characterName}の残りHPは{target.currentHP}。");
        }
        else
        {
            Debug.Log($"{target.characterName}を倒した！");
        }
    }
}
