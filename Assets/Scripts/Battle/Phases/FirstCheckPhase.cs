using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCheckPhase : BattlePhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;

        BattleManager bm = GetBattleManager();
        BattleSystemManager sm = GetBattleSystemManager();

        //敵のListの後ろから順に死んでいるかどうかチェック
        int count = 0;
        for (int i = sm.numOfEnemies-1; i >= 0; i--)
        {
            if (sm.enemies[i].currentHP <= 0)
            {
                Animator animator = sm.enemies[i].GetComponent<Animator>();
                animator.SetBool("Death_Idle", true);
                bm.moveOfEnemy.RemoveAt(i);
                sm.enemies.RemoveAt(i);
                sm.enemyObjects.RemoveAt(i);
                count++;
            }
        }
        sm.numOfEnemies -= count;

        if (sm.numOfEnemies > 0)
        {
            // 味方の行動に関する情報をクリア
            sm.numbersOfAllyInAction.Clear();
            sm.allyObjectsInAction.Clear();
            sm.skillNumbers.Clear();
            sm.numbersOfEnemyInAction.Clear();
            sm.enemyObjectsInAction.Clear();
            sm.currentLoops = 0;
            
            nextPhase = new EnemyMovePhase();
        }
        else
        {
            Debug.Log("敵を全員倒した");
            nextPhase = new EndPhase();
        }
    }
}
