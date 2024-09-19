using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovePhase : PhaseBase
{
    private string dialogue = "敵の攻撃！";

    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;
        Debug.Log("EnemyMovePhase");
        battleContext.textWindow.CreateDialogueText(dialogue);

        GameObject gobj = GameObject.Find("SystemManager");
        SystemManager sm = gobj.GetComponent<SystemManager>();

        // 敵の行動を決めるロジックを記述
        // （動く敵を選ぶ→技を選ぶ→攻撃する味方を選ぶ）×（敵の数）
        //   opponent[i]→skillnumber[i]→self[i]

        for (int i = 0; i < sm.numOfEnemies; i++)
        {
            // 敵の行動順はListの０→１→２で
            sm.opponent.Add(i);
            string itsname = sm.enemies[i].name;
            sm.opponentObject.Add(GameObject.Find(itsname));
            
            // 技選択は乱数を用いてランダムに


            // 攻撃する味方の選択もランダムに


        } 

        SystemManager.enemyCalcuStart = true;

        // 敵の動きのアニメーションを制御するコード
        for (int i = 0; i < sm.numOfEnemies; i++)
        {
            moveOfEnemy[sm.opponent[i]].SetAttackerInfo(sm.opponentObject[i]);
            moveOfAlly [sm.self[i]].SetTargetInfo(sm.selfObject[i]);

            moveOfEnemy[sm.opponent[i]].executeAttackMove = true;
            moveOfAlly[sm.self[i]].executeHurtMove = true;

            yield return new WaitUntil(() => moveOfEnemy[sm.opponent[i]].attackStart == true);
            moveOfEnemy[sm.opponent[i]].AttackAnimationStart();

            yield return new WaitUntil(() => moveOfEnemy[sm.opponent[i]].attackEnd == true);
            moveOfAlly[sm.self[i]].HurtAnimationStart();

            yield return new WaitUntil(() => moveOfAlly[sm.self[i]].hurtEnd == true);
            moveOfEnemy[sm.opponent[i]].executeAfterAttackMove = true;
            moveOfEnemy[sm.self[i]].executeAfterHurtMove = true;

            yield return new WaitUntil(() => moveOfEnemy[sm.self[i]].end == true);

            yield return null;
            moveOfEnemy[sm.opponent[i]].end = false;
            moveOfAlly[sm.self[i]].end = false;

            nextPhase = new SecondCheckPhase();
        }
    }
}
