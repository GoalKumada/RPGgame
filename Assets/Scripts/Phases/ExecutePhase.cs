using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutePhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext)
    {
        yield return null;
        
        Debug.Log("ExecutePhase");

        

        nextPhase = new ResultPhase();
        
    }
}
