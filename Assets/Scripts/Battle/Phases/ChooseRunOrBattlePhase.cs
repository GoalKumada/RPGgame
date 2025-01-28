using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRunOrBattlePhase : BattlePhaseBase
{
    private string dialogue = "どうする？";
    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;
        battleContext.textWindow.CreateDialogueText(dialogue);

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        int index = battleContext.chooseRunOrBattleWindowMenu.currentID;
        battleContext.chooseRunOrBattleWindowMenu.Close();

        BattleSystemManager sm = GetBattleSystemManager();

        if (index == 0) // 0(たたかう)ならChooseAllyPhaseへ
        {
            nextPhase = new ChooseAllyPhase();
            battleContext.chooseAllyWindowMenu.CreateSelectableTexts(sm.GetStringsOfAllies());
            battleContext.chooseAllyWindowMenu.Open();
        }
        else if (index == 1) // 1（にげる）ならRunCheckへ
        {
            nextPhase = new RunCheckPhase();
            battleContext.runCheckWindowMenu.Open();
        }
    }
}
