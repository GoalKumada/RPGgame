using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCommandPhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext)
    {
        yield return null;
        Debug.Log("ChooseCommandPhase");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape));

        battleContext.chooseCommandWindowMenu.Close();

        int currentID = battleContext.chooseCommandWindowMenu.currentID;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentID == 0)
            {
                nextPhase = new ChooseEnemyPhase();
                battleContext.chooseEnemyWindowMenu.Open();
            }
            else if (currentID == 1)
            {
                nextPhase = new ChooseEnemyPhase();
                battleContext.chooseEnemyWindowMenu.Open();
            }
            else
            {
                nextPhase = new ChooseEnemyPhase();
                battleContext.chooseEnemyWindowMenu.Open();
            }
        }
        else
        {
            nextPhase = new ChooseAllyPhase();
            battleContext.chooseAllyWindowMenu.Open();
            battleContext.chooseAllyWindowMenu.Select();
        }
    }
}
