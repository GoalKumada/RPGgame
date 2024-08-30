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

        newMove[ChooseAllyPhase.attacker].executeAttackMove = true;
        newMove[ChooseEnemyPhase.attacked].executeHurtMove = true;

        yield return new WaitUntil(() => newMove[ChooseAllyPhase.attacker].attackStart == true);
        newMove[ChooseAllyPhase.attacker].AttackAnimationStart();

        yield return new WaitUntil(() => newMove[ChooseAllyPhase.attacker].attackEnd == true);
        newMove[ChooseEnemyPhase.attacked].HurtAnimationStart();
        //newMove[ChooseAllyPhase.attacker].attackEnd = false;

        yield return new WaitUntil(() => newMove[ChooseEnemyPhase.attacked].hurtEnd == true);
        newMove[ChooseAllyPhase.attacker].executeAfterAttackMove = true;
        newMove[ChooseEnemyPhase.attacked].executeAfterHurtMove = true;

        yield return new WaitUntil(() => newMove[ChooseEnemyPhase.attacked].end == true);
        
        nextPhase = new ResultPhase();

        yield return null;
        newMove[ChooseAllyPhase.attacker].end = false;
        newMove[ChooseEnemyPhase.attacked].end = false;
        
    }
}