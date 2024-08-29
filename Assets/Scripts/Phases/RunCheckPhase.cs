using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCheckPhase : PhaseBase
{
    private string dialogue = "本当に逃げますか？";

    public override IEnumerator Execute(BattleContext battleContext, NewMove[] newMove)
    {
        yield return null;
        Debug.Log("RunCheckPhase");
        battleContext.textWindow.CreateDialogueText(dialogue);


        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape));

        battleContext.runCheckWindowMenu.Close();

        int index = battleContext.runCheckWindowMenu.currentID;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (index == 0)
            {
                nextPhase = new ChooseRunOrBattlePhase();
                battleContext.chooseRunOrBattleWindowMenu.Open();            }
            else if (index == 1)
            {
                nextPhase = new StartPhase();
            }
        }
        else
        {
            nextPhase = new ChooseRunOrBattlePhase();
            battleContext.chooseRunOrBattleWindowMenu.Open();        }
    }
}
