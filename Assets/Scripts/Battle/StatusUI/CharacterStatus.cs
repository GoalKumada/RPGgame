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

    public void RefreshGaugeOfHP(Character character)
    {
        Transform hpGaugeTransform = transform.Find("GaugePanel/HpGaugeImage");
        GameObject hpGauge = hpGaugeTransform.gameObject;
        GaugeUI gaugeUI = hpGauge.GetComponent<GaugeUI>();
        gaugeUI.fillImage.fillAmount = character.currentHP / character.maxHP;
    }

    public void RefreshGaugeOfTP(Character character)
    {
        Transform tpGaugeTransform = transform.Find("GaugePanel/TpGaugeImage");
        GameObject tpGauge = tpGaugeTransform.gameObject;
        GaugeUI gaugeUI = tpGauge.GetComponent<GaugeUI>();
        gaugeUI.fillImage.fillAmount = (float)character.currentTP / character.maxTP;
    }
}
