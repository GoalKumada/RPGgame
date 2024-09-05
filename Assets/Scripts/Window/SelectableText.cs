using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectableText : Selectable
{
    public UnityAction<Transform> onSelectAction = null; //関数登録用の変数
    
    public void SetText(string text)
    {
        GetComponent<Text>().text = text;
        gameObject.name = text;
    }

    //選択状態になったら実行される関数
    public override void OnSelect(BaseEventData eventData)
    {
        //base.OnSelect(eventData);
        Debug.Log($"{gameObject.transform.GetSiblingIndex()}が選択された");

        //Debug.Log(gameObject.name);
        onSelectAction.Invoke(transform); //登録した関数を実行する
    }

    //非選択状態になったら実行される関数
    public override void OnDeselect(BaseEventData eventData)
    {
        //base.OnSelect(eventData);
        //Debug.Log($"{gameObject.name}の選択が外された");

    }
}
