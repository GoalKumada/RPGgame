using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private string characterName;
    [SerializeField] private float HP;
    [SerializeField] private float TP;
    [SerializeField] private float DEF;

    [SerializeField] public Skill[] skills;


    public void Attack(Character target)
    {
        target.HP -= 5.0f;
        Debug.Log($"{characterName}の攻撃！ {target.characterName}に{5}のダメージ");
    }

    public void UseSkill(Character target, int skillNumber)
    {
        Debug.Log($"{characterName}の「スキル名」! {target.characterName}にxのダメージ");
    }
}
