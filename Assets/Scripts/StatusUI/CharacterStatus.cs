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

    public void SetValueOfHP(float maxHP)
    {
        GameObject valueOfHPText = transform.Find("ValueOfHPText").gameObject;
        Text text = valueOfHPText.GetComponent<Text>();
        text.text = $"{maxHP}/{maxHP}";
    }

    public void SetValueOfTP(float maxTP)
    {
        GameObject valueOfTPText = transform.Find("ValueOfTPText").gameObject;
        Text text = valueOfTPText.GetComponent<Text>();
        text.text = $"{maxTP}/{maxTP}";
    }
}
