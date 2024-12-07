using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WindowMenu : MonoBehaviour
{

    // SelectableTextが選択されたら、カーソルを移動する（親オブジェクトを変更する）

    [SerializeField] List<SelectableText> selectableTexts = new List<SelectableText>();
    [SerializeField] Text arrow;
    [SerializeField] Text arrowPrefab = default;
    [SerializeField] SelectableText selectableTextPrefab = default;
    public int currentID; // 選択中の子要素のID

    public void CreateSelectableTexts(string[] strings)
    {
        foreach (string str in strings)
        {
            SelectableText selectableText = Instantiate(selectableTextPrefab, transform);
            selectableText.SetText(str);
            selectableTexts.Add(selectableText);
        }

        arrow = Instantiate(arrowPrefab, transform);
        arrow.transform.SetParent(selectableTexts[0].transform);

    }

    public void DeleteSelectableTexts() 
    {
        // 選択状態をクリアする
        EventSystem.current.SetSelectedGameObject(null);

        foreach (SelectableText selectableText in selectableTexts)
        {
            Destroy(selectableText.gameObject);
        }

        selectableTexts.Clear();
    }

    public void DeactivateTextByIndex(int index)
    {
        // インデックスが範囲内か確認
        if (index >= 0 && index < selectableTexts.Count)
        {
            selectableTexts[index].gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("インデックスが範囲外です");
        }

        if (!selectableTexts[0].gameObject.activeInHierarchy)
        {
            EventSystem.current.SetSelectedGameObject(selectableTexts[1].gameObject);

        }
        if (!selectableTexts[1].gameObject.activeInHierarchy)
        {
            EventSystem.current.SetSelectedGameObject(selectableTexts[2].gameObject);
        }
    }


    public void SetMoveArrowFunction()
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
        arrow.transform.SetParent(parent);
        currentID = parent.GetSiblingIndex(); // 何番目の子要素かを取得
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

    public void SetSelected()
    {
        EventSystem.current.SetSelectedGameObject(selectableTexts[currentID].gameObject);
    }

    public void SetDeselected()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}
