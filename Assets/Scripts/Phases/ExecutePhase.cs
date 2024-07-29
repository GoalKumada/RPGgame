using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutePhase : PhaseBase
{
    public static GameObject self;
    public static GameObject target;
    
    public override IEnumerator Execute(BattleContext battleContext)
    {
        yield return null;
        
        Debug.Log("ExecutePhase");


        self = ChooseAllyPhase.self;
        target = ChooseEnemyPhase.target;

        Move.setMoveInfoFlag = true;
        Move.moveControlFlag = true;

        yield return new WaitUntil(() => Move.end == true);
        
        nextPhase = new ResultPhase();
        
    }
}
