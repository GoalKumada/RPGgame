using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCheckPhase : PhaseBase
{
    private string dialogue = "本当に逃げますか？";

    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;
        Debug.Log("RunCheckPhase");
        battleContext.textWindow.CreateDialogueText(dialogue);


        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape));

        int index = battleContext.runCheckWindowMenu.currentID;
        battleContext.runCheckWindowMenu.Close();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (index == 0)
            {
                nextPhase = new ChooseRunOrBattlePhase();
                battleContext.chooseRunOrBattleWindowMenu.Open();            }
            else if (index == 1)
            {
                nextPhase = new EndPhase();
            }
        }
        else
        {
            nextPhase = new ChooseRunOrBattlePhase();
            battleContext.chooseRunOrBattleWindowMenu.Open();        }
    }
}
