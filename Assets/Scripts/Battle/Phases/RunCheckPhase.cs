using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCheckPhase : BattlePhaseBase
{
    private string dialogue = "本当に逃げますか？";

    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;
        battleContext.textWindow.CreateDialogueText(dialogue);
        BattleSystemManager sm = GetBattleSystemManager();


        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftShift));

        int index = battleContext.runCheckWindowMenu.currentID;
        battleContext.runCheckWindowMenu.Close();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (index == 0)
            {
                nextPhase = new ChooseRunOrBattlePhase();
                battleContext.chooseRunOrBattleWindowMenu.Open();
            }
            else if (index == 1)
            {
                sm.isEscaped = true;
                string dialogue = "バトルから逃走した";
                battleContext.textWindow.CreateDialogueText(dialogue);
                nextPhase = new EndPhase();
            }
        }
        else
        {
            nextPhase = new ChooseRunOrBattlePhase();
            battleContext.chooseRunOrBattleWindowMenu.Open();
        }
    }
}
