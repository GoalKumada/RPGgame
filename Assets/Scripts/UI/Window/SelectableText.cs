using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectableText : Selectable
{
    public UnityAction<Transform> onSelectAction = null; //関数登録用の変数
    BattleManager bm;

    private new void Awake()
    {
        if (SceneManager.GetActiveScene().name == "BattleScene")
        {
            GameObject obj = GameObject.Find("BattleManager");
            bm = obj.GetComponent<BattleManager>();
            Debug.Log("このシーン上でのみ機能する");
        }
    }

    public void SetText(string text)
    {
        GetComponent<Text>().text = text;
        gameObject.name = text;
    }

    //選択状態になったら実行される関数
    public override void OnSelect(BaseEventData eventData)
    {
        //Debug.Log($"{gameObject.transform.GetSiblingIndex()}が選択された");
        onSelectAction.Invoke(transform); //登録した関数を実行する
    }

    //非選択状態になったら実行される関数
    public override void OnDeselect(BaseEventData eventData)
    {

    }
}
