using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private string characterName;
    [SerializeField] private float HP;
    [SerializeField] private float TP;
    [SerializeField] private float DEF;

    private void Start()
    {

    }

    private void Update()
    {
        
    }

    public void Attack(Character target)
    {
        target.HP -= 5.0f;
        Debug.Log($"{characterName}の攻撃！{target.name}に{5}のダメージ");

    }

    public void UseSkill()
    {

    }
}
