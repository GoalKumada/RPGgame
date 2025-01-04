using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWindow : MonoBehaviour
{
    // TextWindowの一行に収まるのは21文字まで

    [SerializeField] DialogueText dialogueText;
    [SerializeField] DialogueText dialogueTextPrefab;
    BattleSystemManager sm;
    WindowMenu chooseCommandMenu;
    public bool isChooseComandPhase = false;

    private void Start()
    {
        GameObject gobj = GameObject.Find("BattleSystemManager");
        sm = gobj.GetComponent<BattleSystemManager>();

        GameObject obj = GameObject.Find("WindowsPanel");
        Transform target = obj.transform.Find("ChooseCommandWindow");
        chooseCommandMenu = target.GetComponent<WindowMenu>();
    }

    private void Update()
    {
        if (isChooseComandPhase)
        {
            CreateDialogueText(sm.allies[sm.numbersOfAllyInAction[sm.numbersOfAllyInAction.Count-1]].skills[chooseCommandMenu.currentID].skillExplain);
        }
    }

    public void CreateDialogueText(string str)
    {
        if (dialogueText != null)
        {
            Destroy(dialogueText.gameObject);
        }

        DialogueText text = Instantiate(dialogueTextPrefab, transform);
        text.SetText(str);
        dialogueText = text;
    }
}
