using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseEnemyPhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext)
    {
        yield return null;
        Debug.Log("ChooseEnemyPhase");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        
        battleContext.chooseEnemyWindowMenu.gameObject.SetActive(false);

        int currentID_cE = battleContext.chooseEnemyWindowMenu.currentID;

        if (currentID_cE == 0)
        {
            nextPhase = new ExecutePhase();
        }
        else if (currentID_cE == 1)
        {
            nextPhase = new ExecutePhase();
        }
        else
        {
            nextPhase = new ExecutePhase();
        }        
    }
}