using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class WindowMenu : MonoBehaviour
{

    // SelectableTextが選択されたら、カーソルを移動する（親オブジェクトを変更する）

    [SerializeField] Transform arrow = default;
    [SerializeField] List<SelectableText> selectableTexts = new List<SelectableText>();
    [SerializeField] SelectableText selectableTextPrefab = default;
    public int currentID; // 選択中の子要素のID

    public void CreateSelectableText(string[] strings)
    {
        arrow.SetParent(transform);
        foreach (SelectableText selectableText in selectableTexts)
        {
            Destroy(selectableText.gameObject);
        }
        
        selectableTexts.Clear();
        foreach (string str in strings)
        {
            SelectableText text = Instantiate(selectableTextPrefab, transform);
            text.SetText(str);
            selectableTexts.Add(text);
        }
    }

    public void SetMoveArrowFunction()
    {
        foreach (SelectableText selectableText in selectableTexts) 
        {
            selectableText.onSelectAction = MoveArrowTo;
        }

        // 最初から一番上の選択肢を選択状態にする
        //currentID = 0;
        //EventSystem.current.SetSelectedGameObject(selectableTexts[currentID].gameObject);
        
    }
    
    // 親を変更してカーソルを移動する
    public void MoveArrowTo(Transform parent)
    {
        arrow.SetParent(parent);
        currentID = parent.GetSiblingIndex(); // 何番目の子要素かを取得
    }

    public void Select()
    {
        EventSystem.current.SetSelectedGameObject(selectableTexts[currentID].gameObject);
    }

    public void Open()
    {
        currentID = 0;
        //EventSystem.current.SetSelectedGameObject(selectableTexts[currentID].gameObject);
        gameObject.SetActive(true);
        SetMoveArrowFunction();
    }

    public void Close()
    {
        //EventSystem.current.SetSelectedGameObject(null);
        gameObject.SetActive(false);
    }
}
