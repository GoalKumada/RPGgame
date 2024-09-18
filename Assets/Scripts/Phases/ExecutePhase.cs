using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutePhase : PhaseBase
{ 
    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;
        
        Debug.Log("ExecutePhase");

        GameObject gobj = GameObject.Find("SystemManager");
        SystemManager sm = gobj.GetComponent<SystemManager>();

        for (int i = 0; i < sm.numOfAllies; i++)
        {
            moveOfAlly[sm.self[i]].SetAttackerInfo(sm.selfObject[i]);
            moveOfEnemy[sm.opponent[i]].SetTargetInfo(sm.opponentObject[i]);

            moveOfAlly[sm.self[i]].executeAttackMove = true;
            moveOfEnemy[sm.opponent[i]].executeHurtMove = true;

            yield return new WaitUntil(() => moveOfAlly[sm.self[i]].attackStart == true);
            moveOfAlly[sm.self[i]].AttackAnimationStart();

            yield return new WaitUntil(() => moveOfAlly[sm.self[i]].attackEnd == true);
            moveOfEnemy[sm.opponent[i]].HurtAnimationStart();

            yield return new WaitUntil(() => moveOfEnemy[sm.opponent[i]].hurtEnd == true);
            moveOfAlly[sm.self[i]].executeAfterAttackMove = true;
            moveOfEnemy[sm.opponent[i]].executeAfterHurtMove = true;

            yield return new WaitUntil(() => moveOfEnemy[sm.opponent[i]].end == true);
        
            yield return null;
            moveOfAlly[sm.self[i]].end = false;
            moveOfEnemy[sm.opponent[i]].end = false;

            nextPhase = new ResultPhase();
        }
    }
}