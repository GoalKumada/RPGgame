using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext)
    {
        Debug.Log("StartPhase");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        nextPhase = new ChooseRunOrBattlePhase();
        battleContext.chooseRunOrBattleWindowMenu.Open();

    }
}
