using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class WindowMenu : MonoBehaviour
{

    // SelectableTextが選択されたら、カーソルを移動する（親オブジェクトを変更する）

    [SerializeField] Transform arrow = default;
    [SerializeField] List<SelectableText> selectableTexts = new List<SelectableText>();

    public int currentID; // 選択中の子要素のID

    void SetMoveArrowFunction()
    {
        foreach (SelectableText selectableText in selectableTexts) 
        {
            selectableText.onSelectAction = MoveArrowTo;
        }

        // 最初から一番上の選択肢を選択状態にする
        EventSystem.current.SetSelectedGameObject(selectableTexts[currentID].gameObject);
    }
    
    // 親を変更してカーソルを移動する
    public void MoveArrowTo(Transform parent)
    {
        arrow.SetParent(parent);
        currentID = parent.GetSiblingIndex(); // 何番目の子要素かを取得
        //Debug.Log($"カーソル移動:currentID{currentID}");
    }

    public void Select()
    {
        EventSystem.current.SetSelectedGameObject(selectableTexts[currentID].gameObject);
    }

    public void Open()
    {
        currentID = 0;
        gameObject.SetActive(true);
        SetMoveArrowFunction();
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
