using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext)
    {
        yield return null;
        
        nextPhase = new EndPhase();

        Debug.Log("ResultPhase");
    }
}
