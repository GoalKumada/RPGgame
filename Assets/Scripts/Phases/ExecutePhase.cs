using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutePhase : PhaseBase
{ 
    public override IEnumerator Execute(BattleContext battleContext, Move[] move)
    {
        yield return null;
        
        Debug.Log("ExecutePhase");

        move[ChooseAllyPhase.attacker].SetAttackerInfo(ChooseAllyPhase.self);
        move[ChooseEnemyPhase.attacked].SetTargetInfo(ChooseEnemyPhase.target);

        move[ChooseAllyPhase.attacker].executeAttackMove = true;
        move[ChooseEnemyPhase.attacked].executeHurtMove = true;

        yield return new WaitUntil(() => move[ChooseAllyPhase.attacker].attackStart == true);
        move[ChooseAllyPhase.attacker].AttackAnimationStart();

        yield return new WaitUntil(() => move[ChooseAllyPhase.attacker].attackEnd == true);
        move[ChooseEnemyPhase.attacked].HurtAnimationStart();

        yield return new WaitUntil(() => move[ChooseEnemyPhase.attacked].hurtEnd == true);
        move[ChooseAllyPhase.attacker].executeAfterAttackMove = true;
        move[ChooseEnemyPhase.attacked].executeAfterHurtMove = true;

        yield return new WaitUntil(() => move[ChooseEnemyPhase.attacked].end == true);
        
        nextPhase = new ResultPhase();

        yield return null;
        move[ChooseAllyPhase.attacker].end = false;
        move[ChooseEnemyPhase.attacked].end = false;
        
    }
}