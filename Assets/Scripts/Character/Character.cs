using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Move))]

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

    
    public string[] GetSkillStrings()
    {
        List<string> list = new List<string>();
        foreach (Skill skill in skills)
        {
            list.Add(skill.skillName);
        }

        return list.ToArray();
    }


    public string UseSkill(Character target, int skillNumber)
    {
        target.currentHP -= skills[skillNumber].attackPower;
        currentTP -= skills[skillNumber].requiredTP;

        string dialog = $"{characterName}の{skills[skillNumber].skillName}! {target.characterName}に{skills[skillNumber].attackPower}のダメージ";
        
        if (target.currentHP < 0)
        {
            target.currentHP = 0;
        }

        return dialog;
    }
}
