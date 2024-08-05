using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutePhase : PhaseBase
{ 
    public override IEnumerator Execute(BattleContext battleContext, NewMove[] newMove)
    {
        yield return null;
        
        Debug.Log("ExecutePhase");

        newMove[ChooseAllyPhase.attacker].SetAttackerInfo(ChooseAllyPhase.self);
        newMove[ChooseEnemyPhase.attacked].SetTargetInfo(ChooseEnemyPhase.target);

        newMove[ChooseAllyPhase.attacker].attackMoveStart = true;
        newMove[ChooseEnemyPhase.attacked].hurtMoveStart = true;

        yield return new WaitUntil(() => newMove[ChooseAllyPhase.attacker].attackStart == true);
        newMove[ChooseAllyPhase.attacker].AttackStart();

        yield return new WaitUntil(() => newMove[ChooseAllyPhase.attacker].attackEnd == true);
        newMove[ChooseEnemyPhase.attacked].HurtStart();

        yield return new WaitUntil(() => newMove[ChooseEnemyPhase.attacked].hurtEnd == true);
        newMove[ChooseAllyPhase.attacker].afterAttackMoveStart = true;
        newMove[ChooseEnemyPhase.attacked].afterHurtMoveStart = true;

        yield return new WaitUntil(() => newMove[ChooseEnemyPhase.attacked].end == true);
        
        nextPhase = new ResultPhase();
        
    }
}