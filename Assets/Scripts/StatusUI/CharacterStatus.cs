using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatus : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetName(string name)
    {
        GameObject nameText = transform.Find("NameText").gameObject;
        Text text = nameText.GetComponent<Text>();
        text.text = name;
    }

    public void SetValueOfHP(Character character)
    {
        if (character.tag == "Ally")
        {
            GameObject valueOfHPText = transform.Find("ValueOfAllyHPText").gameObject;
            Text text = valueOfHPText.GetComponent<Text>();
            text.text = $"{character.currentHP}/{character.maxHP}";
        }
        else if (character.tag == "Enemy")
        {
            GameObject valueOfHPText = transform.Find("ValueOfEnemyHPText").gameObject;
            Text text = valueOfHPText.GetComponent<Text>();
            text.text = $"{character.currentHP}/{character.maxHP}";
        }
    }

    public void SetValueOfTP(Character character)
    {
        if (character.tag == "Ally")
        {
            GameObject valueOfTPText = transform.Find("ValueOfAllyTPText").gameObject;
            Text text = valueOfTPText.GetComponent<Text>();
            text.text = $"{character.currentTP} / {character.maxTP}";
        }
        else if (character.tag == "Enemy")
        {
            GameObject valueOfTPText = transform.Find("ValueOfEnemyTPText").gameObject;
            Text text = valueOfTPText.GetComponent<Text>();
            text.text = $"{character.currentTP} / {character.maxTP}";
        }
    }
}
