using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseAllyPhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext)
    {
        yield return null;
        Debug.Log("ChooseAllyPhase");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape));

        battleContext.chooseAllyWindowMenu.Close();

        int currentID = battleContext.chooseAllyWindowMenu.currentID;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentID == 0)
            {
                nextPhase = new ChooseCommandPhase();
                battleContext.chooseCommandWindowMenu.Open();
            }
            else if (currentID == 1)
            {
                nextPhase = new ChooseCommandPhase();
                battleContext.chooseCommandWindowMenu.Open();
            }
            else
            {
                nextPhase = new ChooseCommandPhase();
                battleContext.chooseCommandWindowMenu.Open();
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
