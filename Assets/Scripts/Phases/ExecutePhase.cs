using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutePhase : PhaseBase
{ 
    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;
        
        Debug.Log("ExecutePhase");

        moveOfAlly[ChooseAllyPhase.attacker].SetAttackerInfo(ChooseAllyPhase.self);
        moveOfEnemy[ChooseEnemyPhase.attacked].SetTargetInfo(ChooseEnemyPhase.target);

        moveOfAlly[ChooseAllyPhase.attacker].executeAttackMove = true;
        moveOfEnemy[ChooseEnemyPhase.attacked].executeHurtMove = true;

        

        yield return new WaitUntil(() => moveOfAlly[ChooseAllyPhase.attacker].attackStart == true);
        moveOfAlly[ChooseAllyPhase.attacker].AttackAnimationStart();

        yield return new WaitUntil(() => moveOfAlly[ChooseAllyPhase.attacker].attackEnd == true);
        moveOfEnemy[ChooseEnemyPhase.attacked].HurtAnimationStart();

        yield return new WaitUntil(() => moveOfEnemy[ChooseEnemyPhase.attacked].hurtEnd == true);
        moveOfAlly[ChooseAllyPhase.attacker].executeAfterAttackMove = true;
        moveOfEnemy[ChooseEnemyPhase.attacked].executeAfterHurtMove = true;

        yield return new WaitUntil(() => moveOfEnemy[ChooseEnemyPhase.attacked].end == true);
        
        nextPhase = new ResultPhase();

        yield return null;
        moveOfAlly[ChooseAllyPhase.attacker].end = false;
        moveOfEnemy[ChooseEnemyPhase.attacked].end = false;
        
    }
}