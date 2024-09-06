using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPhase : PhaseBase
{
    private string dialogue = "戦闘開始！";

    public override IEnumerator Execute(BattleContext battleContext, Move[] move)
    {
        Debug.Log("StartPhase");
        battleContext.textWindow.CreateDialogueText(dialogue);

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));



        nextPhase = new ChooseRunOrBattlePhase();
        battleContext.chooseRunOrBattleWindowMenu.Open();
    }
}
