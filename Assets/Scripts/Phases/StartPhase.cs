using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPhase : PhaseBase
{
    private string dialogue = "戦闘開始！";

    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        Debug.Log("StartPhase");
        battleContext.textWindow.CreateDialogueText(dialogue);

        // ToDo:戦闘開始時に味方と敵のListをManagerに渡す処理を書く


        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        nextPhase = new ChooseRunOrBattlePhase();
        battleContext.chooseRunOrBattleWindowMenu.Open();
    }
}
