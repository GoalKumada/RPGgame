using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCheckPhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext, NewMove[] newMove)
    {
        yield return null;
        Debug.Log("RunCheckPhase");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape));

        battleContext.runCheckWindowMenu.Close();

        int currentID = battleContext.runCheckWindowMenu.currentID;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentID == 0)
            {
                nextPhase = new ChooseRunOrBattlePhase();
                battleContext.chooseRunOrBattleWindowMenu.Open();
                battleContext.chooseRunOrBattleWindowMenu.Select();
            }
            else
            {
                nextPhase = new StartPhase();
            }
        }
        else
        {
            nextPhase = new ChooseRunOrBattlePhase();
            battleContext.chooseRunOrBattleWindowMenu.Open();
            battleContext.chooseRunOrBattleWindowMenu.Select();
        }
    }
}
