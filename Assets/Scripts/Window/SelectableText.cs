using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectableText : Selectable
{
    public UnityAction<Transform> onSelectAction = null; //関数登録用の変数
    
    //選択状態になったら実行される関数
    public override void OnSelect(BaseEventData eventData)
    {
        //base.OnSelect(eventData);
        Debug.Log($"{gameObject.name}が選択された");
        onSelectAction.Invoke(transform); //登録した関数を実行する
    }

    //非選択状態になったら実行される関数
    public override void OnDeselect(BaseEventData eventData)
    {
        //base.OnSelect(eventData);
        Debug.Log($"{gameObject.name}の選択が外された");

    }
    

}