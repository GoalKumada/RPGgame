using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext, Move[] move)
    {
        yield return null;
        
        Debug.Log("ResultPhase");

        if (SystemManager.canContinueFighting)
        {
            nextPhase = new ChooseRunOrBattlePhase();
            battleContext.chooseRunOrBattleWindowMenu.Open();

        }
        else
        {
            nextPhase = new EndPhase();
        }
    }
}
