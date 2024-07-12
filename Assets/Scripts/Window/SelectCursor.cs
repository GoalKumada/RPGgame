using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SelectCursor : MonoBehaviour
{

    // SelectableTextが選択されたら、カーソルを移動する（親オブジェクトを変更する）

    [SerializeField] Transform arrow = default;
    [SerializeField] List<SelectableText> selectableTexts = new List<SelectableText>();

    public int currentID; // 選択中の子要素のID

    private void Start()
    {
        // test
        SetMoveArrowFunction();

    }



    void SetMoveArrowFunction()
    {
        foreach (SelectableText selectableText in selectableTexts) 
        {
            selectableText.onSelectAction = MoveArrowTo;
        }

        // 最初から味方１を選択状態にする
        EventSystem.current.SetSelectedGameObject(selectableTexts[currentID].gameObject);
    }
    
    // 親を変更してカーソルを移動する
    public void MoveArrowTo(Transform parent)
    {
        arrow.SetParent(parent);
        currentID = parent.GetSiblingIndex();
        Debug.Log($"カーソル移動:currentID{currentID}");
    }
}
