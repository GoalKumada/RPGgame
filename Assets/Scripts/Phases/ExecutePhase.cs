using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutePhase : PhaseBase
{
    Move move = new Move();
    public override IEnumerator Execute(BattleContext battleContext)
    {
        yield return null;
        
        Debug.Log("ExecutePhase");


        GameObject self = ChooseAllyPhase.self;
        GameObject target = ChooseEnemyPhase.target;

        move.SetMoveInfo(self,target);

        //while (!move.end)
        {
            move.moveControl(self,target);
        }
        
        nextPhase = new ResultPhase();
        
    }
}
